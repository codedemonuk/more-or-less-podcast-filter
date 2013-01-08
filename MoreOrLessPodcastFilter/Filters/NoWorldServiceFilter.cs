using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace MoreOrLessPodcastFilter.Filters
{
    public class NoWorldServiceFilter : IFilter
    {
        public XDocument Execute(XDocument unfilteredFeed)
        {
			return unfilteredFeed;
        }
    }
}