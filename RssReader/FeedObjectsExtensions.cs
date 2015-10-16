using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader
{
    static class FeedObjectsExtensions
    {
        public static void SortByPublishDate(this List<FeedItem> list)
        {
            list.Sort((x, y) =>
            {
                return (int)(y.PublishDate - x.PublishDate).Ticks;
            });
        }
    }
}
