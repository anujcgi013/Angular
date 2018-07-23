using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Volvo.NVS.Core.Unity.Configuration;
using Volvo.VSS.LogDomain.ServiceLayer;
using Volvo.VSS.LogDomain.DomainLayer;
using Volvo.VSS.LogDomain.DomainLayer.RepositoryInterfaces;
using Volvo.VSS.LogDomain.InfrastructureLayer.Repositories;

namespace Volvo.VSS.LogDomain
{
    public class LogDomainConfigurator : IContainerConfigurator
    {
        public void Configure(IUnityContainer container)
        {
            container.RegisterType<ILogService, LogService>()
                 .RegisterType<IProcessLogRepository, ProcessLogRepository>()
                 .RegisterType<IEventLogRepository, EventLogRepository>()
                 .RegisterType<IMaintenanceInformationRepository, MaintenanceInformationRepository>();
        }
    }
}
