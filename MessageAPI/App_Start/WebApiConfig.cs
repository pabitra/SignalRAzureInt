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

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
