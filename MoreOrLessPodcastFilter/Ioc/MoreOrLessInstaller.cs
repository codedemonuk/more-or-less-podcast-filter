using System.Configuration;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MoreOrLessPodcastFilter.Filters;
using MoreOrLessPodcastFilter.Readers;

namespace MoreOrLessPodcastFilter.Ioc
{
	public class MoreOrLessInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Component.For<IReader>().ImplementedBy<WebRssReader>()
					.DependsOn(new { podcastUri = FromConfigurationFile("PodcastUri") }),

				Component.For<IFilter>().ImplementedBy<NoWorldServiceFilter>(),

				Component.For<IHttpHandler>().ImplementedBy<MoreOrLessHandler>()
					.Named("/MOREORLESS.ASHX")
				);
		}

		private static string FromConfigurationFile(string settingKey)
		{
			return ConfigurationManager.AppSettings[settingKey];
		}
	}
}