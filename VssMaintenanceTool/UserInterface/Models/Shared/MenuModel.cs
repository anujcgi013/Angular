using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Volvo.NVS.Utilities.Web.Extensions;
using Volvo.NVS.Utilities.Web.Localization;
using Volvo.MaintenanceTool.UserInterface.Common.Helpers;
using Volvo.MaintenanceTool.UserInterface.Controllers;

namespace Volvo.MaintenanceTool.UserInterface.Models.Shared
{
    /// <summary>
    /// Represents a common menu model used to trace selected menu items.
    /// </summary>
    public class MenuModel : ISelectableMenu
    {
        /// <summary>
        /// A name of the current UI culture selected for the application.
        /// </summary>
        public string CultureName { get; set; }

        /// <summary>
        /// A name of the current theme selected for the application.
        /// </summary>
        public string ThemeName { get; set; }

        /// <summary>
        /// A bundling and minification state for the application.
        /// </summary>
        public bool BundlingEnabled { get; set; }

        /// <summary>
        /// The controller name from the Request
        /// </summary>
        private string RequestedController;

        /// <summary>
        /// The action name from the Request
        /// </summary>
        private string RequestedAction;

        /// <summary>
        /// A localization helper to be used by the model.
        /// </summary>
        private readonly ILocalizationHelper localizationHelper;

        /// <summary>
        /// A key used to store information about the current menu state in a View Data dictionary.
        /// </summary>
        public static string Key = typeof(MenuModel).Name;

        /// <summary>
        /// Creates an instance of the menu model.
        /// </summary>
        /// <param name="localizationHelper">A localization helper to be used by the model.</param>
        public MenuModel(ILocalizationHelper localizationHelper)
        {
            //if (localizationHelper == null)
            //{
            //    throw new ArgumentNullException("localizationHelper");
            //}
            //this.localizationHelper = localizationHelper;
        }

        /// <summary>
        /// Loads and initializes the menu model.
        /// </summary>
        public void Load(HttpContextBase context)
        {
            //CultureName = localizationHelper.GetCurrentCultureName(context);

            // Store locally the controller and action from the Request
            RequestedController = context.Request.GetController();
            RequestedAction = context.Request.GetAction();
        }

        /// <summary>
        /// A name of the action which is applied to the Home related menu items.
        /// </summary>
        private static readonly string HomeMenuItemControllerName = "Home";

        /// <summary>
        /// Determines if a menu item for the specified controller action should be marked as selected or not.
        /// </summary>
        /// <param name="menuItemControllerName">A menu item controller name.</param>
        /// <param name="menuItemAction">A menu item action name from the controller.</param>
        /// <param name="menuItemArguments">A string representing all the arguments passed into the menu item action.</param>
        /// <returns>True if a menu item for the given controller, action and its arguments should be selected.</returns>
        public bool IsMenuItemSelected(string menuItemControllerName, string menuItemAction, string menuItemArguments)
        {
            // Since the automatic selection was disabled and we are doing things manually, we must also enable the first level (root) items.
            return IsFirstLevelHighlightableMenuItem(menuItemControllerName, menuItemAction);
        }

        /// <summary>
        /// Determines if a menu item is a first level one and should be highlighted.
        /// </summary>
        /// <param name="menuItemControllerName">The menu item controller name.</param>
        /// <param name="menuItemAction">The menu item action name.</param>
        /// <returns>True if the menu item is a first level (root) one and if it should be highlighted. False otherwise.</returns>
        public bool IsFirstLevelHighlightableMenuItem(string menuItemControllerName, string menuItemAction)
        {
            return (menuItemControllerName == HomeMenuItemControllerName
                    && menuItemControllerName == RequestedController
                    && menuItemAction == RequestedAction);
        }
    }
}