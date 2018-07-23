using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Volvo.NVS.Core.Unity;
using Volvo.NVS.Utilities.Web.Localization;

namespace Volvo.MaintenanceTool.UserInterface.Controllers
{
    public class ErrorController : BaseController
    {
        public ErrorController() 
        {
        }

        public ActionResult Index()
        {
            ViewBag.Controller = "Error";
            ViewBag.Action = "Index";
            return View();
        }
    }
}
