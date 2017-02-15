using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using SERVICES.API;
using SERVICES.MIDDLEWARES;
using log4net;


[assembly: OwinStartup(typeof(SERVICES.API.Startup))]
namespace SERVICES.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //configure Web API 
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}
