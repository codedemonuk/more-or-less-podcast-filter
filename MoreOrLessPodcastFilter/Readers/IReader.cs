using System.Xml.Linq;

namespace MoreOrLessPodcastFilter.Readers
{
    public interface IReader
    {
        XDocument Execute();
    }
}