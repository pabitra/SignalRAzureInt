﻿using System.Web.Http;
using Microsoft.Owin.Security.OAuth;

namespace MessageAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
          
            // Web API routes
            config.MapHttpAttributeRoutes();
            
            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
