using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;

namespace RssReader
{
    public class FeedItem
    {
        public string Source { get; private set; }
        public string Title { get; private set; }
        public string Summary { get; private set; }
        public Uri Link { get; private set; }
        public DateTimeOffset PublishDate { get; private set; }

        public FeedItem(SyndicationItem item, string source)
        {
            Title = item.Title.Text;
            Summary = item.Summary.Text;
            Source = source;
            PublishDate = item.PublishDate;

            if (item.Links.Count > 0)
                Link = item.Links[0].Uri;
            else
                Link = null;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
