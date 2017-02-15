using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SERVICES.WebUI.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            //Si la petición es del tipo AJAX se devuelve un JSON y STATUS 500
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                //Return JSON
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { error = true, message = "Exception:"+filterContext.Exception.Message,stack="StackTrace:"+filterContext.Exception.StackTrace.ToString()  }
                };

                filterContext.HttpContext.Response.Status = "500";
  
            }
            else
                {
                //Redirigimos a la pagina de error
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                
                System.Web.Routing.RouteValueDictionary values = new System.Web.Routing.RouteValueDictionary();
                values.Add("msg", filterContext.Exception.Message);
                values.Add("controllerOriginal", controllerName);
                values.Add("ActionOriginal", actionName);
                filterContext.ExceptionHandled = true;
                
                filterContext.Result = this.RedirectToAction("ExceptionError", "Error", values);
            }

            base.OnException(filterContext);
        }
    }
}