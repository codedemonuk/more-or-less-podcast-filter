using System.Xml.Linq;

namespace MoreOrLessPodcastFilter
{
    public interface IReader
    {
        XDocument Execute();
    }
}