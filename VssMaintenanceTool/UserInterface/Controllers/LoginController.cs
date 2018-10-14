using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Volvo.MaintenanceTool.UserInterface.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Index(String txtUserName)
        //{
        //    Session["BaldoUserId"] = txtUserName;
        //    return RedirectToAction("Index", "Home");
        //}
    }
}