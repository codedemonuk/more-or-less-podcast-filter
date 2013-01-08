using System.Xml.Linq;

namespace MoreOrLessPodcastFilter.Filters
{
	public class UnfilteredFilter : IFilter
	{
		public XDocument Execute(XDocument unfilteredFeed)
		{
			return unfilteredFeed;
		}
	}
}