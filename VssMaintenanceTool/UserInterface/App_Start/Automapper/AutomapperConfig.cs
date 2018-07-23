using Volvo.NVS.Utilities.Automapper;

namespace Volvo.MaintenanceTool.UserInterface.Automapper
{
    /// <summary>
    /// Configures the AutoMapper for the complete web application
    /// </summary>
    public static class AutomapperConfig
    {

        /// <summary>
        /// Configure the AutoMapper globally for the complete web application.
        /// </summary>
        public static void Configure()
        {
            // Register all the AutoMapper profiles which are defined in the unity configuration and registered in the container
            // Check the Unity.config configuration file for details about the currently mapped AutoMapper Profiles
            //AutoMapperConfiguration.RegisterProfiles();
        }

    }

}