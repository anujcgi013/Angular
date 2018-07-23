using System.Collections.Generic;
using System.Configuration;
using System.Web.Optimization;
using CssRewriteUrlTransformWrapper = Volvo.NVS.Utilities.Web.Bundling.CssRewriteUrlTransformWrapper;
using Volvo.NVS.Utilities.Web.Bundling;
using Volvo.NVS.Utilities.Web.Extensions;

namespace Volvo.MaintenanceTool.UserInterface.Bundling
{
    public class AppBundleCollectionService : BundleCollectionServiceBase
    {
        ///<summary>
        /// Current available brands
        /// </summary>
        private readonly IList<string> availableBrands = new List<string>
        {
            "Mack",
            "MackDual",
            "Renault",
            "Violin",
            "VolvoBA",
            "VolvoGroup"
        };

        public override void RegisterScriptBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Js/CommonJsBundle").Include(
               "~/Scripts/jquery-1.9.1.min.js",
               "~/Content/Bootstrap/Scripts/bootstrap.min.js",
                string.Format("~/Scripts/kendo/{0}/kendo.all.min.js", ConfigurationManager.AppSettings["KendoVersion"]),
                string.Format("~/Scripts/kendo/{0}/kendo.aspnetmvc.min.js", ConfigurationManager.AppSettings["KendoVersion"]),
                "~/Scripts/nvs/nvs.common.js",
                "~/Scripts/messageBoardhelper.js",
                "~/Scripts/calendarhelper.js"
                  ).DisableOrdering());

            // Validation (this one is minified)
            bundles.Add(new ScriptBundle("~/Scripts/Js/ValidationJsBundle").Include(
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/nvs/nvs.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js",
                "~/Scripts/nvs/nvs.validate.unobtrusive.adapters.js").DisableOrdering());         
        }

        /// <summary>
        /// Registers a CSS bundle for each of the specific brands/themes
        /// </summary>
        /// <param name="bundles">The bundle collection</param>
        public override void RegisterStyleBundles(BundleCollection bundles)
        {
            foreach (var brand in availableBrands)
            {
                var bundleName = string.Format("~/Content/nvs/{0}/CssBundle", brand);
                bundles.Add(new StyleBundle(bundleName)
                    //.Include("~/Content/nvs/nvs.base.common.css", new CssRewriteUrlTransformWrapper())
                    // NVS base styles
                    //.Include(string.Format("~/Content/nvs/nvs.base.{0}.css", brand), new CssRewriteUrlTransformWrapper())
                    .Include(string.Format("~/Content/kendo/{0}/kendo.common.min.css", ConfigurationManager.AppSettings["KendoVersion"]), new CssRewriteUrlTransformWrapper()) // NVS Kendo styles
                    .Include(string.Format("~/Content/nvs/nvs.kendo.themebuilder.{0}.css", brand), new CssRewriteUrlTransformWrapper())
                    .Include("~/Content/nvs/nvs.kendo.common.css", new CssRewriteUrlTransformWrapper())
                    .Include(string.Format("~/Content/nvs/nvs.kendo.{0}.css", brand), new CssRewriteUrlTransformWrapper()).DisableOrdering());
            }
        }
    }
}