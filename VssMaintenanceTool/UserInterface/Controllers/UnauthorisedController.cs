using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Volvo.MaintenanceTool.UserInterface.Controllers
{
    public class UnauthorisedController : BaseController
    {
        // GET: Unauthorised
        public ActionResult Index()
        {
            Session.Abandon();
            return View();
        }
        public ActionResult AccessDenied()
        {
            ViewBag.Message = "You do not have sufficient privilege to access.";
            return View();
        }
    }
}