using System.Web.Mvc;
using System.Web.Routing;

namespace Volvo.MaintenanceTool.UserInterface.Routes
{
    /// <summary>
    /// Configures all the routes registring them.
    /// </summary>
    public static class RoutesConfig
    {

        /// <summary>
        /// Register the ASP .NET routes.
        /// </summary>
        /// <param name="routes">Collection of routes.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.log");

            // For learning how to add custom routing visit: http://www.asp.net/learn/mvc/tutorial-23-cs.aspx


            // This is the default routing map 
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
                );

            // Add our route registration for MvcSiteMapProvider sitemaps
            //MvcSiteMapProvider.Web.Mvc.XmlSiteMapController.RegisterRoutes(routes);

        }

    }

}