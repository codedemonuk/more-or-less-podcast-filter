using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace MoreOrLessPodcastFilter.Filters
{
	public class WorldServiceOnlyFilter : IFilter
	{
		private readonly string _worldServiceTitlePattern;

		public WorldServiceOnlyFilter(string worldServiceTitlePattern)
	    {
		    _worldServiceTitlePattern = worldServiceTitlePattern;
	    }

	    public XDocument Execute(XDocument unfilteredFeed)
	    {
		    var filteredFeed = unfilteredFeed;
			var items = filteredFeed.Descendants("item").ToList();
		    
			foreach (var item in items)
			{
				if ( item.Element("title") == null)
					continue;

				// ReSharper disable PossibleNullReferenceException
				var nodeTitle = item.Element("title").Value;
				// ReSharper restore PossibleNullReferenceException
				
				if ( !Regex.IsMatch(nodeTitle, _worldServiceTitlePattern))
				{
					item.Remove();
				}
			}

			return filteredFeed;
        }
	}
}