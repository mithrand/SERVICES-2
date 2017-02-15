using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OAuthServer.DI;
using Microsoft.Practices.Unity;

namespace OAuthServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new UnityContainer();
            RegisterIOC(container);
            config.DependencyResolver = new UnityResolver(container);
        }

        private static void RegisterIOC(UnityContainer container)
        {
            container.RegisterType<>(new HierarchicalLifetimeManager());
        }
    }
}
