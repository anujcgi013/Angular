using Common;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Repositories;
using Volvo.NVS.Persistence.NHibernate.SessionHandling;
using Volvo.VSS.ProcessDomain.DomainLayer.Common;
using Volvo.VSS.ProcessDomain.DomainLayer.Entities;
using Volvo.VSS.ProcessDomain.DomainLayer.RepositoryInterfaces;

namespace Volvo.VSS.ProcessDomain.InfrastructureLayer.Repositories
{
    public class ProcessInstanceRepository : GenericRepository<ProcessInstance, string>, IProcessInstanceRepository
    {
        private ProcessInstanceDTO processInstancesDTO;
        public ProcessInstanceRepository()
        {

        }

        public ProcessInstanceRepository(string name) : base(name)
        {
        }

        public IList<ProcessInstance> GetProcessList(int take, int skip)
        {
            IList<ProcessInstance> processList;
            using (new NHibernateSessionContext(SessionName))
            {
                processList = Session.QueryOver<ProcessInstance>().OrderBy(x => x.CreatedAt).Desc.Skip(skip).Take(take).List();
            }
            return processList;
        }

        public IList<ProcessInstance> GetProcessDeatils(ProcessInstanceSearch searchCriteria)
        {
            IList<ProcessInstance> processList;
            using (new NHibernateSessionContext(SessionName))
            {

                ICriteria query = Session.CreateCriteria<ProcessInstance>();

                if (searchCriteria.ProcessId.HasValue)
                {
                    query.Add(Restrictions.Eq("ProcessId", searchCriteria.ProcessId.Value));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.InterfaceName))
                {
                    query.Add(Restrictions.Eq("InterfaceName", searchCriteria.InterfaceName));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.FIFOTag))
                {
                    query.Add(Restrictions.Eq("FIFOTag", searchCriteria.FIFOTag));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.FIFOTag2))
                {
                    query.Add(Restrictions.Eq("FIFOTag2", searchCriteria.FIFOTag2));
                }
                if (searchCriteria.State.HasValue)
                {
                    query.Add(Restrictions.Eq("State", searchCriteria.State));
                }
                if (searchCriteria.Status.HasValue)
                {
                    query.Add(Restrictions.Eq("Status", searchCriteria.Status));
                }
                if (searchCriteria.StartDate.HasValue)
                {
                    query.Add(Restrictions.Ge("CreatedAt", searchCriteria.StartDate));
                }
                if (searchCriteria.EndDate.HasValue)
                {
                    query.Add(Restrictions.Le("UpdatedAt", searchCriteria.EndDate));
                }
                processList = query.List<ProcessInstance>();
            }
            return processList;
        }

        public ProcessInstance GetProcessDeatilsByProcessId(Guid processId)
        {
            ProcessInstance process;
            using (new NHibernateSessionContext(SessionName))
            {
                process = Session.QueryOver<ProcessInstance>().Where(x => x.ProcessId == processId).SingleOrDefault();
            }
            return process;
        }
        public IList<ProcessRunStatusEnum> GetProcessRunStatusEnumList()
        {
            IList<ProcessRunStatusEnum> result;
            using (new NHibernateSessionContext(SessionName))
            {
                result = Session.QueryOver<ProcessRunStatusEnum>().OrderBy(x => x.Name).Asc.List();
            }
            return result;
        }
        public IList<ProcessDefinition> GetProcessDefinitionList()
        {
            IList<ProcessDefinition> result;
            using (new NHibernateSessionContext(SessionName))
            {
                result = Session.QueryOver<ProcessDefinition>().OrderBy(x => x.Name).Asc.List();
            }
            return result;
        }

        //------------- Process Instance --------------- 03-Feb-2018------------- Start ------------
        public ProcessInstanceDTO GetProcessInstances(ProcessInstanceSearch searchCriteria)
        {
            var Skip = searchCriteria.Skip;
            var Take = searchCriteria.Take;
            processInstancesDTO = new ProcessInstanceDTO();
            using (new NHibernateSessionContext(SessionName))
            {
                ICriteria query = this.Session.CreateCriteria(typeof(ProcessInstance)).AddOrder(Order.Desc("UpdatedAt"));
                if (searchCriteria.ProcessId.HasValue)
                {
                    query.Add(Restrictions.Eq("ProcessId", searchCriteria.ProcessId.Value));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.InterfaceName))
                {
                    query.Add(Restrictions.Like("InterfaceNameId", "%" + searchCriteria.InterfaceName + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.FIFOTag))
                {
                    query.Add(Restrictions.Like("FIFOTag", "%" + searchCriteria.FIFOTag + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.FIFOTag2))
                {
                    query.Add(Restrictions.Like("FIFOTag2", "%" + searchCriteria.FIFOTag2 + "%"));
                }
                if (searchCriteria.State.HasValue)
                {
                    query.Add(Restrictions.Eq("State", searchCriteria.State));
                }
                if (searchCriteria.Status.HasValue)
                {
                    query.Add(Restrictions.Eq("StatusId", searchCriteria.Status));
                }
                if (searchCriteria.StartDate.HasValue)
                {
                    query.Add(Restrictions.Ge("UpdatedAt", searchCriteria.StartDate));
                }
                if (searchCriteria.EndDate.HasValue)
                {
                    query.Add(Restrictions.Le("UpdatedAt", searchCriteria.EndDate));
                }

                processInstancesDTO.ProcessInstanceList = query.SetFirstResult(Skip).SetMaxResults(Take).Future<ProcessInstance>().ToList();
                //processInstancesDTO.Total = query.SetProjection(Projections.Count(Projections.Id())).FutureValue<int>().Value;
                
            }
            using (new NHibernateSessionContext(SessionName))
            {
                ICriteria query = this.Session.CreateCriteria(typeof(ProcessInstance));
                if (searchCriteria.ProcessId.HasValue)
                {
                    query.Add(Restrictions.Eq("ProcessId", searchCriteria.ProcessId.Value));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.InterfaceName))
                {
                    query.Add(Restrictions.Like("InterfaceNameId", "%" + searchCriteria.InterfaceName + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.FIFOTag))
                {
                    query.Add(Restrictions.Like("FIFOTag", "%" + searchCriteria.FIFOTag + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.FIFOTag2))
                {
                    query.Add(Restrictions.Like("FIFOTag2", "%" + searchCriteria.FIFOTag2 + "%"));
                }
                if (searchCriteria.State.HasValue)
                {
                    query.Add(Restrictions.Eq("State", searchCriteria.State));
                }
                if (searchCriteria.Status.HasValue)
                {
                    query.Add(Restrictions.Eq("StatusId", searchCriteria.Status));
                }
                if (searchCriteria.StartDate.HasValue)
                {
                    query.Add(Restrictions.Ge("UpdatedAt", searchCriteria.StartDate));
                }
                if (searchCriteria.EndDate.HasValue)
                {
                    query.Add(Restrictions.Le("UpdatedAt", searchCriteria.EndDate));
                }

                //processInstancesDTO.ProcessInstanceList = query.SetFirstResult(Skip).SetMaxResults(Take).Future<ProcessInstance>().ToList();
                processInstancesDTO.Total = query.SetProjection(Projections.Count(Projections.Id())).FutureValue<int>().Value;

            }
            return processInstancesDTO; 
        }

       

        public ProcessInstance GetProcessDetail(Guid processId)
        {
            ProcessInstance process;
            using (new NHibernateSessionContext(SessionName))
            {
                process = Session.QueryOver<ProcessInstance>().Where(x => x.ProcessId == processId).SingleOrDefault();
            }
            return process;
        }

        public int ReProcess(Guid processId)
        {
            int result = 1;
            using (new NHibernateSessionContext(SessionName))
            {
                var query = Session.CreateSQLQuery("EXEC Process.ReProcessMessage @ProcessId= :ProcessId");
                query.SetGuid("ProcessId", processId);
                
                object res = query.UniqueResult();
                result = Convert.ToInt32(res);

            }
            return result;
        }
    }
}
