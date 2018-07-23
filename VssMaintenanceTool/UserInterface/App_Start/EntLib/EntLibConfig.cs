using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection;

namespace Volvo.MaintenanceTool.UserInterface.EntLib
{
    /// <summary>
    /// Configures the Enterprise Library bootstrapping its blocks.
    /// </summary>
    public static class EntLibConfig
    {

        /// <summary>
        /// Configures the Enterprise Library bootstrapping its blocks.
        /// </summary>
        public static void Configure()
        {
            // Base the configuration of the Enterprise Library on the current application configuration file.
            IConfigurationSource source = ConfigurationSourceFactory.Create();

            // Setup logger which will be used by other blocks
            //var logwriterFactory = new LogWriterFactory(source);
            //var logWriter = logwriterFactory.Create();
            //Logger.SetLogWriter(logWriter);

            // Set the policy injector so the policy injection block can be used.
            //PolicyInjector policyInjector = new PolicyInjector(source);
            //PolicyInjection.SetPolicyInjector(policyInjector);

            // Set the exception manager so ExceptionPolicy can be used. 
            //var exceptionPolicyFactory = new ExceptionPolicyFactory(source);
            //var exceptionManager = exceptionPolicyFactory.CreateManager();
            //ExceptionPolicy.SetExceptionManager(exceptionManager);

        }

    }
}