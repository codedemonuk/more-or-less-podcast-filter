using System.Web;
using Castle.Windsor;

namespace MoreOrLessPodcastFilter.Ioc
{
	public class CastleWindsorHttpHandlerFactory : IHttpHandlerFactory
	{
		private static IWindsorContainer _container;

		public CastleWindsorHttpHandlerFactory()
		{
			if (_container == null)
			{
				_container = ((IContainerAccessor)HttpContext.Current.ApplicationInstance).Container;
			}
		}

		public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
		{
			return _container.Resolve<IHttpHandler>(url.ToUpperInvariant());
		}

		public void ReleaseHandler(IHttpHandler handler)
		{
			_container.Release(handler);
		}
	}
}