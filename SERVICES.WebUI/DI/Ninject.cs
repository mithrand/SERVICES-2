using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Moq;
using SERVICES.REPO;
using SERVICES.MODEL;


namespace HELPERS.DI
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        
        /*
        protected override IController GetControllerInstance(RequestContext requestContext,Type controllerType)
        {
            return controllerType == null? null:(IController)ninjectKernel.Get(controllerType);
        }
        */

        private void AddBindings()
        {
            // put additional bindings here

            Mock<IOrdenesRepository> mock = new Mock<IOrdenesRepository>();

            List<Orden> ordenes = new List<Orden>
            {
                new Orden { OrdenId=1,Codigo="COD001",FechaAcordada=DateTime.Today, FechaAlta=DateTime.Today,Motivo="", Prioridad=1 },
                new Orden { OrdenId=2,Codigo="COD002",FechaAcordada=DateTime.Today, FechaAlta=DateTime.Today,Motivo="", Prioridad=4 },
                new Orden { OrdenId=3,Codigo="COD003",FechaAcordada=DateTime.Today, FechaAlta=DateTime.Today,Motivo="", Prioridad=5 },
            };

            mock.Setup(m => m.GetAll()).Returns(ordenes.AsQueryable());

            ninjectKernel.Bind<IOrdenesRepository>().ToConstant(mock.Object);
        }
    }
}