using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.Repositories;
using Volvo.VSS.ProcessDomain.DomainLayer.Common;
using Volvo.VSS.ProcessDomain.DomainLayer.Entities;

namespace Volvo.VSS.ProcessDomain.DomainLayer.RepositoryInterfaces
{
    public interface IProcessInstanceRepository : IGenericRepository<ProcessInstance, string>
    {
        IList<ProcessInstance> GetProcessDeatils(ProcessInstanceSearch searchCriteria);
        IList<ProcessInstance> GetProcessList(int take, int skip);
        ProcessInstance GetProcessDetail(Guid processId);
        IList<ProcessRunStatusEnum> GetProcessRunStatusEnumList();
        IList<ProcessDefinition> GetProcessDefinitionList();
        ProcessInstanceDTO GetProcessInstances(ProcessInstanceSearch searchCriteria);
        int ReProcess(Guid processId);
    }
}
