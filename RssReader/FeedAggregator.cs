using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Timers;

namespace RssReader
{
    public class FeedAggregator
    {
        private const int timerInterval = 1000;
        private const long defaultRefreshInterval = 600000000; //60 seconds

        private List<string> sources;
        private string[] filterSources;
        private List<FeedItem> feed;
        private List<FeedItem> filteredFeed;

        private DateTime lastUpdated;
        private TimeSpan refreshInterval;

        private Timer timer;
        private object syncRoot = new object();

        private NewsSender newsSender;
        
        public FeedItem[] Feed
        {
            get { lock (syncRoot) { return feed.ToArray(); } }
        }

        public FeedItem[] FilteredFeed
        {
            get { lock (syncRoot) { return filteredFeed?.ToArray() ?? feed.ToArray(); } }
        }

        public DateTime LastUpdated
        {
            get { lock (syncRoot) { return lastUpdated; } }
        }

        public TimeSpan RefreshInterval
        {
            get { lock (syncRoot) { return refreshInterval; } }
            set { lock (syncRoot) { refreshInterval = value; } }
        }

        public string[] SourceFilter
        {
            get { lock (syncRoot) { return (string[])filterSources?.Clone(); } }
            set
            {
                lock (syncRoot)
                {
                    foreach (var source in value)
                        if (!sources.Contains(source))
                            throw new ArgumentException("\"" + source + "\" is not a member of this aggregator's source list.");

                    filterSources = (string[])value.Clone();
                }
            }
        }

        public string[] RecipientAddresses
        {
            get { return newsSender.RecipientAddresses; }
            set { newsSender.RecipientAddresses = value; }
        }

        public event EventHandler FeedRefreshed;
        public event EventHandler FilteredFeedRefreshed;
        public event EventHandler NewsletterSent;

        public FeedAggregator()
        {
            sources = new List<string>();
            feed = new List<FeedItem>();
            lastUpdated = DateTime.MinValue;
            refreshInterval = new TimeSpan(defaultRefreshInterval);
            newsSender = new NewsSender(@"abc@abc.com", @"qwerty");

            timer = new Timer(timerInterval);
            timer.Elapsed += OnTimerElapsed;
            timer.Start();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now - lastUpdated > refreshInterval)
                RefreshFeed();
        }

        public void AddSource(string source)
        {
            IEnumerable<FeedItem> newFeed;

            try
            {
                newFeed = GetFeed(source);
            }
            catch (Exception e)
            {
                throw new Exception("Unable to add source: " + e.Message, e);
            }

            lock (syncRoot)
            {
                sources.Add(source);

                feed = feed.Concat(newFeed).ToList();
                feed.SortByPublishDate();
            }
        }

        public void Refresh()
        {
            Task.Factory.StartNew(RefreshFeed);
        }

        private void RefreshFeed()
        {
            if (sources.Count > 0)
            {
                IEnumerable<FeedItem> newFeed = null;

                string[] sourcesCopy;
                lock (syncRoot)
                {
                    sourcesCopy = sources.ToArray();
                }

                foreach (var source in sources)
                {
                    if (newFeed == null)
                        newFeed = GetFeed(source);
                    else
                        newFeed = newFeed.Concat(GetFeed(source));
                }

                lock (syncRoot)
                {
                    feed = newFeed.ToList();
                    feed.SortByPublishDate();
                }
            }

            lock (syncRoot)
            {
                lastUpdated = DateTime.Now;
            }

            FeedRefreshed?.Invoke(this, new EventArgs());

            bool filterSet;
            lock (syncRoot)
            {
                filterSet = filterSources != null && filterSources.Length > 0;
            }
            if (filterSet)
                Task.Factory.StartNew(FilterBySource);
            else
                FilteredFeedRefreshed?.Invoke(this, new EventArgs());

        }

        private IEnumerable<FeedItem> GetFeed(string source)
        {
            XmlReader reader = null;
            SyndicationFeed syndicationFeed;

            //validate feed source
            try
            {
                reader = XmlReader.Create(source);
                syndicationFeed = (SyndicationFeed.Load(reader));
            }
            catch (Exception e)
            {
                throw new Exception("Unable to retrieve RSS feed from \"" + source + "\".", e);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            var result = syndicationFeed.Items.Select(syndicationItem => new FeedItem(syndicationItem, source)).ToList();
            result.SortByPublishDate();
            return result;
        }

        public string[] GetSources()
        {
            lock (syncRoot)
            {
                return sources.ToArray();
            }
        }

        public void RemoveSource(string source)
        {
            lock (syncRoot)
            {
                try
                {
                    sources.Remove(source);
                }
                catch (Exception e)
                {
                    throw new Exception("Unable to remove source: " + e.Message, e);
                }
            }
        }

        private void FilterBySource()
        {
            FeedItem[] feedCopy;
            string[] acceptedSourcesCopy;
            lock (syncRoot)
            {
                feedCopy = feed.ToArray();
                acceptedSourcesCopy = (string[])filterSources.Clone();
            }

            List<FeedItem> filterResult = feedCopy.Where(feedItem => acceptedSourcesCopy.Contains(feedItem.Source)).ToList();

            lock (syncRoot) { filteredFeed = filterResult; }

            FilteredFeedRefreshed?.Invoke(this, new EventArgs());
        }

        public void SendNewsletter(bool filtered)
        {
            Task.Factory.StartNew(() => Send(filtered));
        }

        private void Send(bool filtered)
        {
            FeedItem[] feedCopy;
            if (filtered)
                lock (syncRoot) { feedCopy = filteredFeed?.ToArray() ?? feed.ToArray(); }
            else
                lock (syncRoot) { feedCopy = feed.ToArray(); }

            newsSender.SendNewsItems(feedCopy);

            NewsletterSent?.Invoke(this, new EventArgs());
        }
    }
}
