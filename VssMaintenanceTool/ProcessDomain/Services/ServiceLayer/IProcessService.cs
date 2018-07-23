using Common;
using System.Collections.Generic;
using Volvo.VSS.ProcessDomain.DomainLayer.Entities;
using System;
using Volvo.VSS.ProcessDomain.DomainLayer.Common;

namespace Volvo.VSS.ProcessDomain.ServiceLayer
{
    public interface IProcessService
    {
        IList<ProcessInstance> GetProcessDeatils(ProcessInstanceSearch searchCriteria);
        IList<ProcessInstance> GetProcessList(PageSettings paging);
        ProcessInstance GetProcessDetail(Guid processId);
        IList<ProcessRunStatusEnum> GetProcessRunStatusEnumList();
        IList<ProcessDefinition> GetProcessDefinitionList();
        ProcessInstanceDTO GetProcessInstances(ProcessInstanceSearch searchCriteria);
        int ReProcess(Guid processId);
    }
}