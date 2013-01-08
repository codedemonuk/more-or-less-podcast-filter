using System;
using System.Web;
using MoreOrLessPodcastFilter.Filters;
using MoreOrLessPodcastFilter.Readers;

namespace MoreOrLessPodcastFilter.Handlers
{
	public class MoreOrLessHandler : IHttpHandler
	{
		private readonly IReader _reader;
		private readonly IFilter _filter;
		private const string RssMimeType = "application/rss+xml";

		public MoreOrLessHandler(IReader reader, IFilter filter)
		{
			if (reader == null) throw new ArgumentNullException("reader");
			if (filter == null) throw new ArgumentNullException("filter");

			_reader = reader;
			_filter = filter;
		}

		public void ProcessRequest(HttpContext context)
		{
			var nativeFeed = _reader.Execute();
			var filteredFeed = _filter.Execute(nativeFeed);

			context.Response.ContentType = RssMimeType;
			context.Response.StatusCode = 200;
			context.Response.Write(filteredFeed);
			context.Response.Flush();
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}