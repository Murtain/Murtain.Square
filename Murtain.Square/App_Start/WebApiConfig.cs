using Murtain.Web.Attributes;
using Murtain.Web.ContractResolver;
using Murtain.Web.HttpControllerSelectors;
using Murtain.Web.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Murtain.Square
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                  name: "namespace",
                  routeTemplate: "api/{namespace}/{controller}/{id}",
                  constraints: new { @namespace = @"v1|v2|v3" },
                  defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(config));

            config.Filters.Add(new WebApiExceptionFilterAttribute());
            config.Filters.Add(new ModelValidateAttribute());

            //Remove and JsonValueProviderFactory and add JsonDotNetValueProviderFactory
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new SnakeCaseContractResolver();
            config.MessageHandlers.Add(new DefaultHandler());
        }
    }
}
