using Murtain.SDK.Attributes;
using Murtain.SDK.Models;
using Murtain.Web.Attributes;
using Murtain.Web.ContractResolver;
using Murtain.Web.Exceptions;
using Murtain.Web.HttpControllerSelectors;
using Murtain.Web.MessageHandlers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Filters;

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

            config.Filters.Add(new Murtain.Square.WebApiExceptionFilterAttribute());
            config.Filters.Add(new ModelValidateAttribute());

            //Remove and JsonValueProviderFactory and add JsonDotNetValueProviderFactory
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new SnakeCaseContractResolver();
            config.MessageHandlers.Add(new DefaultHandler());
        }
    }


    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private static JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
        {
            ContractResolver = new SnakeCaseContractResolver()
        };
        public override void OnException(HttpActionExecutedContext context)
        {
            var request = context.Request.RequestUri.AbsolutePath;

            var response = new ResponseContentModel(WebApiExceptionReturnCode.INTERNAL_SERVER_ERROR, request);

            if (context.Exception is NotImplementedException)
            {
                response = new ResponseContentModel(WebApiExceptionReturnCode.NOT_IMPLEMENTED, request);
            }
            if (context.Exception is WebException)
            {
                response = new ResponseContentModel(WebApiExceptionReturnCode.GATEWAY_TIMEOUT, request);
            }
            if (context.Exception is UserFriendlyException)
            {
                var exception = context.Exception as UserFriendlyException;
                response = new ResponseContentModel(exception.Code, exception.Message, request);
            }

            context.Response = new HttpResponseMessage(response.HttpStatusCode)
            {
                Content = new StringContent(JsonConvert.SerializeObject(response, serializerSettings), Encoding.UTF8, "application/json")
            };
        }
    }

    public enum WebApiExceptionReturnCode
    {

        /// <summary>
        /// 服务器上发生一般性错误
        /// </summary>
        [Description("服务器上发生一般性错误")]
        [HttpCorresponding(HttpStatusCode.InternalServerError)]
        INTERNAL_SERVER_ERROR,
        /// <summary>
        /// 服务器不支持所请求的功能
        /// </summary>
        [Description("服务器不支持所请求的功能")]
        [HttpCorresponding(HttpStatusCode.NotImplemented)]
        NOT_IMPLEMENTED,
        /// <summary>
        /// 中间代理服务器在等待来自另一个代理或原始服务器的响应时已超时
        /// </summary>
        [Description("中间代理服务器在等待来自另一个代理或原始服务器的响应时已超时")]
        [HttpCorresponding(HttpStatusCode.BadGateway)]
        GATEWAY_TIMEOUT
    }
}
