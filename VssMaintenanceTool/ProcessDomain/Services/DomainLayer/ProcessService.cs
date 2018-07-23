using Common;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Volvo.NVS.Core.Unity;
using Volvo.NVS.Persistence.NHibernate.SessionHandling;
using Volvo.NVS.Persistence.Specifications;
using Volvo.VSS.ProcessDomain.DomainLayer.Common;
using Volvo.VSS.ProcessDomain.DomainLayer.Entities;
using Volvo.VSS.ProcessDomain.DomainLayer.RepositoryInterfaces;
using Volvo.VSS.ProcessDomain.InfrastructureLayer.Repositories;
using Volvo.VSS.ProcessDomain.ServiceLayer;

namespace Volvo.VSS.ProcessDomain.DomainLayer
{
    public class ProcessService: IProcessService
    {
        protected IProcessInstanceRepository ProcessInstanceRepository { get; }

        public ProcessService()
        {
            ProcessInstanceRepository = Container.Resolve<IProcessInstanceRepository>();
        }

        public ProcessService(IProcessInstanceRepository processRepository)
        {
            ProcessInstanceRepository = processRepository;
        }
        public IList<ProcessInstance> GetProcessDeatils(ProcessInstanceSearch searchCriteria)
        {
            return ProcessInstanceRepository.GetProcessDeatils(searchCriteria);
        }

        public IList<ProcessInstance> GetProcessList(PageSettings paging)
        {
            paging.PageNumber = (paging.PageNumber == 0) ? 1 : paging.PageNumber;
            int itemsToSkip = (paging.PageNumber-1) * paging.ItemsPerPage;

            return ProcessInstanceRepository.GetProcessList(paging.ItemsPerPage, itemsToSkip);
        }

        public ProcessInstance GetProcessDetail(Guid processId)
        {
            return ProcessInstanceRepository.GetProcessDetail(processId);
        }
        public IList<ProcessRunStatusEnum> GetProcessRunStatusEnumList()
        {
            return ProcessInstanceRepository.GetProcessRunStatusEnumList();
        }

        public IList<ProcessDefinition> GetProcessDefinitionList()
        {
            return ProcessInstanceRepository.GetProcessDefinitionList();
        }
        public ProcessInstanceDTO GetProcessInstances(ProcessInstanceSearch searchCriteria)
        {
            return ProcessInstanceRepository.GetProcessInstances(searchCriteria);
        }
        public int ReProcess(Guid processId)
        {
            return ProcessInstanceRepository.ReProcess(processId);
        }
    }
}