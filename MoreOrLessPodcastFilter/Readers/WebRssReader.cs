using System;
using System.Xml.Linq;

namespace MoreOrLessPodcastFilter.Readers
{
	public class WebRssReader : IReader
	{
		private readonly Uri _podcastLocation;

		public WebRssReader(string podcastUri)
		{
			_podcastLocation = new Uri(podcastUri);
		}

		public XDocument Execute()
		{
			var document = XDocument.Load(_podcastLocation.ToString());
			return document;
		}
	}
}
