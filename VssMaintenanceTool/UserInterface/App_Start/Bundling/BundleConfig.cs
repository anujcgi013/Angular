using System.Web.Optimization;

using Volvo.NVS.Core.Unity;
using Volvo.NVS.Utilities.Web.Bundling;

namespace Volvo.MaintenanceTool.UserInterface.Bundling
{

    /// <summary>
    /// The class configures the bundling within the web application.
    /// </summary>
    public static class BundleConfig
    {

        /// <summary>
        /// Configure the bundling for the web application.
        /// </summary>
        public static void Configure()
        {
            // We are using the unity itself in order to resolve the configuration object, service
            // This service acts here like the configuration helper and will do the configuration for us
            // Check the NVSBundleCollectionService class for details about the configuration service
            Container.Resolve<IBundleConfig>().InitializeBundles(BundleTable.Bundles);
        }

    }

}