using System;
using System.Web;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace MoreOrLessPodcastFilter
{
	public class Global : HttpApplication, IContainerAccessor
	{
		private static IWindsorContainer _container;

		protected void Application_Start(object sender, EventArgs e)
		{
			// Bootstrap container
			_container = new WindsorContainer().Install(FromAssembly.This());
		}

		#region Empty methods
		protected void Session_Start(object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{

		}
		#endregion

		protected void Application_End(object sender, EventArgs e)
		{
			_container.Dispose();
		}

		public IWindsorContainer Container
		{
			get { return _container; }
		}
	}
}
