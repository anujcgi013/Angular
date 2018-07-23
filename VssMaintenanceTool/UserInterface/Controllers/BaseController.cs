using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Volvo.NVS.Utilities.Web.Controllers;
using Volvo.NVS.Utilities.Web.Localization;
using Volvo.MaintenanceTool.UserInterface.Models.Shared;

namespace Volvo.MaintenanceTool.UserInterface.Controllers
{
    /// <summary>
    /// Acts like a base controller for all application MVC controllers. Provides common and shared functionality.
    /// </summary>
    public class BaseController : NVSController
    {
        /// <summary>
        /// A localization helper to be used by the model.
        /// </summary>
        protected readonly ILocalizationHelper LocalizationHelper;

        /// <summary>
        /// Creates an instance of the base application controller.
        /// </summary>
        /// <param name="localizationHelper">A localization helper to be used by the model.</param>
        /// <param name="themesHelper">A themes helper to be used by the model.</param>
        /// <param name="bundlingHelper">A bundling helper to be used by the model.</param>
        public BaseController()
        {
       
        }
        public BaseController(ILocalizationHelper localizationHelper)
        {
            LocalizationHelper = localizationHelper;
        }

        /// <summary>
        /// Called before the action method is invoked
        /// </summary>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            // The menu model must always be available for all the views (as menu it always presented)
            // so its data is prepared for every single MVC action being executed.
            InitializeMenuModel();

            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// Reads information about the current state of the menu and makes it available for a view.
        /// </summary>
        protected virtual void InitializeMenuModel()
        {
            MenuModel model = new MenuModel(LocalizationHelper);
            model.Load(HttpContext);
            ViewData[MenuModel.Key] = model;
        }

    }
}