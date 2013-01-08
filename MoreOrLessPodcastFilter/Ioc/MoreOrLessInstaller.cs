using System.Configuration;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MoreOrLessPodcastFilter.Filters;
using MoreOrLessPodcastFilter.Handlers;
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

				Component.For<IFilter>().ImplementedBy<NoWorldServiceFilter>()
					.Named("NoWorldService")
					.DependsOn(new { worldServiceTitlePattern = FromConfigurationFile("WorldServiceTitlePattern") }),

				Component.For<IFilter>().ImplementedBy<WorldServiceOnlyFilter>()
					.Named("WorldService")
					.DependsOn(new { worldServiceTitlePattern = FromConfigurationFile("WorldServiceTitlePattern") }),

				Component.For<IFilter>().ImplementedBy<UnfilteredFilter>()
					.Named("Unfiltered"),

				Component.For<IHttpHandler>().ImplementedBy<MoreOrLessHandler>()
					.Named("/RADIO4.XML")
					.DependsOn(Property.ForKey("filter").Is("NoWorldService")),

				Component.For<IHttpHandler>().ImplementedBy<MoreOrLessHandler>()
					.Named("/WORLDSERVICE.XML")
					.DependsOn(Property.ForKey("filter").Is("WorldService")),

				Component.For<IHttpHandler>().ImplementedBy<MoreOrLessHandler>()
					.Named("/ALL.XML")
					.DependsOn(Property.ForKey("filter").Is("Unfiltered"))
			);
		}

		private static string FromConfigurationFile(string settingKey)
		{
			return ConfigurationManager.AppSettings[settingKey];
		}
	}
}