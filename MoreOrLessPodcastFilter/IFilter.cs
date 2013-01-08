using System.Xml.Linq;

namespace MoreOrLessPodcastFilter
{
    public interface IFilter
    {
        XDocument Execute(XDocument nativeFeed);
    }
}