using Murtain.Auditing.Startup;
using Murtain.Configuration.Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Murtain.Square
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            StartupConfig.RegisterDependency(config =>
            {
                //应用程序配置
                //config.GlobalSettingsConfiguration.Providers.Add<AuthorizationSettingProvider>();
                //config.CacheSettingsConfiguration.Providers.Add<MessageCaptchaCacheSettingProvider>();

                //本地化
                //config.LocalizationConfiguration.Sources.Add(new DictionaryBasedLocalizationSource(Constants.Localization.SourceName.Messages, new XmlEmbeddedFileLocalizationDictionaryProvider(Assembly.GetExecutingAssembly(), Constants.Localization.RootNamespace.Messages)));
                //config.LocalizationConfiguration.Sources.Add(new DictionaryBasedLocalizationSource(Constants.Localization.SourceName.Events, new XmlEmbeddedFileLocalizationDictionaryProvider(Assembly.GetExecutingAssembly(), Constants.Localization.RootNamespace.Events)));
                //config.LocalizationConfiguration.Sources.Add(new DictionaryBasedLocalizationSource(Constants.Localization.SourceName.Scopes, new XmlEmbeddedFileLocalizationDictionaryProvider(Assembly.GetExecutingAssembly(), Constants.Localization.RootNamespace.Scopes)));
                //config.LocalizationConfiguration.Sources.Add(new DictionaryBasedLocalizationSource(Constants.Localization.SourceName.Views, new XmlEmbeddedFileLocalizationDictionaryProvider(Assembly.GetExecutingAssembly(), Constants.Localization.RootNamespace.Views)));

                //EF 连接字符串
                config.UseDataAccessEntityFramework(cfg =>
                {
                    cfg.DefaultNameOrConnectionString = "DefaultConnection";
                });

                config.UseAuditing();
                config.UseAutoMapper();

                config.RegisterWebMvcApplication(new ConventionalRegistrarConfig());
                config.RegisterWebApiApplication();
            });
        }
    }


    public class ConventionalRegistrarConfig : Autofac.Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            //builder.RegisterType<UserAccountService>()
            //    .As<IUserAccountService>()
            //    .AsImplementedInterfaces()
            //    .EnableInterfaceInterceptors()
            //    .InterceptedBy(typeof(UnitOfWorkInterceptor))
            //    .InstancePerDependency();
            //base.Load(builder);
        }
    }
}
