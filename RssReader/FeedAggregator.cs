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
        private List<string> sources;
        private Timer timer;

        public List<FeedItem> Feed { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public TimeSpan RefreshInterval { get; set; }

        public event EventHandler FeedRefreshed;

        public FeedAggregator()
        {
            sources = new List<string>();
            Feed = new List<FeedItem>();
            LastUpdated = DateTime.MinValue;
            RefreshInterval = new TimeSpan(0, 1, 0); //1 minute interval as default

            timer = new Timer(1000); //checks every 1 seconds
            timer.Elapsed += OnTimerElapsed;
            timer.Start();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now - LastUpdated > RefreshInterval)
                Refresh();
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

            sources.Add(source);

            Feed = Feed.Concat(newFeed).ToList();
            Feed.SortByPublishDate();
        }

        public void Refresh()
        {
            if (sources.Count > 0)
            {
                IEnumerable<FeedItem> newFeed = null;

                foreach (var source in sources)
                {
                    if (newFeed == null)
                        newFeed = GetFeed(source);
                    else
                        newFeed = newFeed.Concat(GetFeed(source));
                }

                Feed = newFeed.ToList();
                Feed.SortByPublishDate();
            }

            LastUpdated = DateTime.Now;
            if (FeedRefreshed != null)
                FeedRefreshed(this, new EventArgs());
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

            return syndicationFeed.Items.Select(syndicationItem => new FeedItem(syndicationItem, source));
        }

        public string[] GetSources()
        {
            return sources.ToArray();
        }

        public void RemoveSource(string source)
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
}
