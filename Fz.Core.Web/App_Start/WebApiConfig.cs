using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Fz.Core.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {           
            // Web API 配置和服务
            // Web API 路由
            config.MapHttpAttributeRoutes();          
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // Web API configuration and services 跨域配置
          //  var cors = new EnableCorsAttribute("*", "*", "*");
          //  config.EnableCors(cors);
        }
    }
}
