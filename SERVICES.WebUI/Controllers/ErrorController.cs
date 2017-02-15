using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVICES.WebUI.Controllers
{
    public class ErrorController : BaseController
    {
        public ViewResult Index()
        {
            return View("Error404");
        }

        
        public ViewResult NotFound()
        {
            Response.StatusCode = 404;  //you may want to set this to 200
            return View("404");
        }


        public ViewResult SystemError()
        {
            Response.StatusCode = 500;  //you may want to set this to 200
            return View("500");
        }

        public ViewResult ExceptionError(string msg,string controllerOriginal, string ActionOriginal)
        {
            Response.StatusCode = 500;  //you may want to set this to 200
            ViewBag.msg = msg;
            ViewBag.controller = controllerOriginal;
            ViewBag.action = ActionOriginal;
            return View("Exception");
        }

        public ViewResult test()
        {

            throw new Exception("Mi nuevo error");
            
        }
    }
}