using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OAuthServer.DI;
using Microsoft.Practices.Unity;
using OAuth.Interfaces;
using SERVICES.REPO;
using SERVICES.MODEL;

namespace OAuthServer
{
    public static class UnityConfig
    {
        public static void Register(HttpConfiguration config)
        {          
            var container = new UnityContainer();
            RegisterIOC(container);
            config.DependencyResolver = new UnityResolver(container);
        }

        private static void RegisterIOC(UnityContainer container)
        {
            container.RegisterType<IAuthRepo, UsuariosRepository>();
            container.RegisterType<IUserModel, Usuario>();
            container.RegisterType<IServicesDBContext, ServicesDBContext>();
        }
    }
}