using System;
using System.Web;

namespace MoreOrLessPodcastFilter
{
    public class MoreOrLess : IHttpHandler
    {
        private readonly IReader _reader;
        private readonly IFilter _filter;
        private const string RssMimeType = "application/rss+xml";

        public MoreOrLess(IReader reader, IFilter filter)
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
            context.Response.Write(filteredFeed);
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