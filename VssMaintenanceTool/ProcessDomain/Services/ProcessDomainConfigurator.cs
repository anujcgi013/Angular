using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Volvo.NVS.Core.Unity.Configuration;
using Volvo.VSS.ProcessDomain.ServiceLayer;
using Volvo.VSS.ProcessDomain.DomainLayer;
using Volvo.VSS.ProcessDomain.DomainLayer.RepositoryInterfaces;
using Volvo.VSS.ProcessDomain.InfrastructureLayer.Repositories;

namespace Volvo.VSS.ProcessDomain
{
    public class ProcessDomainConfigurator : IContainerConfigurator
    {
        public void Configure(IUnityContainer container)
        {
            container.RegisterType<IProcessService, ProcessService>()
                //.RegisterType<IProcessInstanceRepository, ProcessInstanceRepository>("hibernate-configuration-process");
                .RegisterType<IProcessInstanceRepository, ProcessInstanceRepository>();
            
        }
    }
}
