using System.Xml.Linq;

namespace MoreOrLessPodcastFilter.Filters
{
    public interface IFilter
    {
        XDocument Execute(XDocument nativeFeed);
    }
}