using System;
using Ninject;
using log4net;
using SERVICES.REPO;
using SERVICES.MODEL;


namespace SERVICES.API.DI
{
    public static class myNinjectBinding
    {
        public static void bindings(IKernel kernel)
        {
            kernel.Bind<ILog>().ToMethod(x => LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType));
            kernel.Bind<IServicesDBContext>().To<ServicesDBContext>();
            kernel.Bind<IOrdenesRepository>().To<OrdenesRepository>();
        }
    }
}