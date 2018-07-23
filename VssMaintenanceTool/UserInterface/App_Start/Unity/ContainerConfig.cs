using Volvo.NVS.Core.Configuration;
using Volvo.NVS.Core.Unity;
using Volvo.VSS.LogDomain;
using Volvo.VSS.ProcessDomain;
using Volvo.VSSMaintenance.UserDomain.Configuration;
using Volvo.VSSMaintenance.UserDomain.DomainLayer;
using Volvo.VSSMaintenance.UserDomain.ServiceLayer;

namespace Volvo.MaintenanceTool.UserInterface.Unity
{
    /// <summary>
    /// Configures the Unity for the complete application.
    /// </summary>
    /// <remarks>
    /// Check also the <see cref="Container"/> documentation.
    /// </remarks>
    public static class ContainerConfig
    {
        /// <summary>
        /// Configures the unity container for the complete application.
        /// </summary>
        public static void Configure()
        {
            // Configure the container using the default application configuration file.
            // In our case the unity node will be searched in the Web.config for the web application.
            LibraryConfigurator.Current
                .ConfigureContainer(configure => configure.FromConfigurator(new UserDomainConfigurator()));
            LibraryConfigurator.Current
                .ConfigureContainer(configure => configure.FromConfigurator(new LogDomainConfigurator()));
            LibraryConfigurator.Current
               .ConfigureContainer(configure => configure.FromConfigurator(new ProcessDomainConfigurator()));
            //   Container.RegisterType<IUserService, UserService>();
            // NVS Integration for WebSpehere MQ(IInputChannel, IOutputChannel, IReplyChannel)
            //.ConfigureIntegrationMQChannels(builder => builder.RegisterChannels());
            LibraryConfigurator.Current.ConfigureContainer(config => config.FromApplicationConfigurationFile());
        }
    }
}