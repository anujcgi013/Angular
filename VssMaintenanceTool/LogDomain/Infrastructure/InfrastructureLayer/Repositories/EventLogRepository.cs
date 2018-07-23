using Common;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Transactions;
using Volvo.NVS.Persistence.NHibernate.Repositories;
using Volvo.NVS.Persistence.NHibernate.SessionHandling;
using Volvo.VSS.LogDomain.DomainLayer.Common;
using Volvo.VSS.LogDomain.DomainLayer.Entities;
using Volvo.VSS.LogDomain.DomainLayer.RepositoryInterfaces;

namespace Volvo.VSS.LogDomain.InfrastructureLayer.Repositories
{
    public class EventLogRepository : GenericRepository<EventLog, string>, IEventLogRepository
    {
        private EventLogDTO eventLogDTO;
        private IntegrationMessageDTO integrationMessageDTO;
        public EventLogRepository()
        {
        }
        public EventLogRepository(string name) : base(name)
        {
        }
        public IList<EventLog> GetEventLog(EventLogSearch searchCriteria, int take, int skip)
        {
            IList<EventLog> eventLogList;
            using (new NHibernateSessionContext(SessionName))
            {

                ICriteria query = Session.CreateCriteria<EventLog>();

                if (searchCriteria.Id.HasValue)
                {
                    query.Add(Restrictions.Eq("Id", searchCriteria.Id.Value));
                }
                if (searchCriteria.Severity.HasValue)
                {
                    query.Add(Restrictions.Eq("Severity", searchCriteria.Severity));
                }
                if (searchCriteria.RequestId.HasValue)
                {
                    query.Add(Restrictions.Eq("RequestId", (searchCriteria.RequestId.Value)));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.BusinessId))
                {
                    query.Add(Restrictions.Like("BusinessId", "%" + searchCriteria.BusinessId + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.Message))
                {
                    query.Add(Restrictions.Like("Message", "%" + searchCriteria.Message + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.MachineName))
                {
                    query.Add(Restrictions.Eq("MachineName", "%" + searchCriteria.MachineName + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.UserId))
                {
                    query.Add(Restrictions.Ge("UserId", "%" + searchCriteria.UserId + "%"));
                }
                if (searchCriteria.StartDate.HasValue)
                {
                    query.Add(Restrictions.Ge("Timestamp", searchCriteria.StartDate));
                }
                if (searchCriteria.EndDate.HasValue)
                {
                    query.Add(Restrictions.Le("Timestamp", searchCriteria.EndDate));
                }
                eventLogList = query.SetFirstResult(0).SetMaxResults(50).List<EventLog>();
            }
            return eventLogList;
        }

        public IList<EventLog> GetEventLogList(int itemsPerPage, int itemsToSkip)
        {
            IList<EventLog> value;
            using (new NHibernateSessionContext(SessionName))
            {
                //TODO : Implement Like
                value = Session.QueryOver<EventLog>().OrderBy(x => x.Timestamp).Desc.Skip(itemsToSkip).Take(itemsPerPage).List();
            }
            return value;
        }

        public IntegrationMessageDTO GetIntegrationMessage(IntegrationMessageSearch searchCriteria)
        {
            integrationMessageDTO = new IntegrationMessageDTO();
            var skip = searchCriteria.Skip;
            var take = searchCriteria.Take;
            using (new NHibernateSessionContext(SessionName))
            {
                ICriteria query = Session.CreateCriteria<IntegrationMessage>().AddOrder(Order.Desc("TimeStamp"));

                if (searchCriteria.Id.HasValue)
                {
                    query.Add(Restrictions.Like("IntegrationMessageId", searchCriteria.Id.Value));
                }
                if (searchCriteria.System.HasValue)
                {
                    query.Add(Restrictions.Eq("SystemId", searchCriteria.System));
                }
                if (searchCriteria.Status.HasValue)
                {
                    query.Add(Restrictions.Eq("StatusId", (searchCriteria.Status.Value)));
                }
                if (searchCriteria.MessageType.HasValue)
                {
                    query.Add(Restrictions.Eq("MessageTypeId", searchCriteria.MessageType));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.Message))
                {
                    query.Add(Restrictions.Like("Message", "%" + searchCriteria.Message + "%"));
                }
                if (searchCriteria.StartTimeStamp.HasValue)
                {
                    query.Add(Restrictions.Ge("TimeStamp", searchCriteria.StartTimeStamp));
                }
                if (searchCriteria.EndTimeStamp.HasValue)
                {
                    query.Add(Restrictions.Le("TimeStamp", searchCriteria.EndTimeStamp));
                }
                integrationMessageDTO.integrationMessagelist = query.SetFirstResult(skip).SetMaxResults(take).List<IntegrationMessage>();
            }
            using (new NHibernateSessionContext(SessionName))
            {
                ICriteria query = Session.CreateCriteria<IntegrationMessage>();

                if (searchCriteria.Id.HasValue)
                {
                    query.Add(Restrictions.Like("IntegrationMessageId", searchCriteria.Id.Value));
                }
                if (searchCriteria.System.HasValue)
                {
                    query.Add(Restrictions.Eq("SystemId", searchCriteria.System));
                }
                if (searchCriteria.Status.HasValue)
                {
                    query.Add(Restrictions.Eq("StatusId", (searchCriteria.Status.Value)));
                }
                if (searchCriteria.MessageType.HasValue)
                {
                    query.Add(Restrictions.Eq("MessageTypeId", searchCriteria.MessageType));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.Message))
                {
                    query.Add(Restrictions.Like("Message", "%" + searchCriteria.Message + "%"));
                }
                if (searchCriteria.StartTimeStamp.HasValue)
                {
                    query.Add(Restrictions.Ge("TimeStamp", searchCriteria.StartTimeStamp));
                }
                if (searchCriteria.EndTimeStamp.HasValue)
                {
                    query.Add(Restrictions.Le("TimeStamp", searchCriteria.EndTimeStamp));
                }
                integrationMessageDTO.Total = query.SetProjection(Projections.Count(Projections.Id())).FutureValue<int>().Value;
            }
            return integrationMessageDTO;
        }

        public IList<IntegrationMessageStatusEnum> GetIntegrationMessageStatusEnumList()
        {
            IList<IntegrationMessageStatusEnum> result; ;
            using (new NHibernateSessionContext(SessionName))
            {
                result = Session.QueryOver<IntegrationMessageStatusEnum>().OrderBy(m => m.Name).Asc.List();
            }
            return result;
        }

        public IList<IntegrationMessageTypeEnum> GetIntegrationMessageTypeEnumList()
        {
            IList<IntegrationMessageTypeEnum> result; ;
            using (new NHibernateSessionContext(SessionName))
            {
                result = Session.QueryOver<IntegrationMessageTypeEnum>().OrderBy(m => m.Name).Asc.List();
            }
            return result;
        }

        public IList<SystemEnum> GetSystemEnumList()
        {
            IList<SystemEnum> result; ;
            using (new NHibernateSessionContext(SessionName))
            {
                result = Session.QueryOver<SystemEnum>().OrderBy(m => m.Name).Asc.List();
            }
            return result;
        }

        public IList<BusinessIdTypeEnum> GetBusinessIdTypeEnumList()
        {
            IList<BusinessIdTypeEnum> result; ;
            using (new NHibernateSessionContext(SessionName))
            {
                result = Session.QueryOver<BusinessIdTypeEnum>().OrderBy(m => m.Name).Asc.List();
            }
            return result;
        }

        public IList<SeverityTypeEnum> GetSeverityTypeEnumList()
        {
            IList<SeverityTypeEnum> result; ;
            using (new NHibernateSessionContext(SessionName))
            {
                result = Session.QueryOver<SeverityTypeEnum>().OrderBy(m => m.Name).Asc.List();
            }
            return result;
        }

        public EventLogDTO GetEventLogs(EventLogSearch searchCriteria)
        {
            var Skip = searchCriteria.Skip;
            var Take = searchCriteria.Take;
            eventLogDTO = new EventLogDTO();
            using (new NHibernateSessionContext(SessionName))
            {
                ICriteria query = this.Session.CreateCriteria(typeof(EventLog)).AddOrder(Order.Desc("Timestamp"));
                if (searchCriteria.Id.HasValue)
                {
                    query.Add(Restrictions.Eq("EventLogId", searchCriteria.Id.Value));
                }
                if (searchCriteria.Severity.HasValue)
                {
                    query.Add(Restrictions.Eq("SeverityId", searchCriteria.Severity));
                }
                if (searchCriteria.RequestId.HasValue)
                {
                    query.Add(Restrictions.Eq("RequestId", (searchCriteria.RequestId.Value)));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.BusinessId))
                {
                    query.Add(Restrictions.Eq("BusinessId", "%" + searchCriteria.BusinessId + "%"));
                }
                if (searchCriteria.BusinessIdType.HasValue)
                {
                    query.Add(Restrictions.Eq("BusinessIdTypeId", searchCriteria.BusinessIdType));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.Message))
                {
                    query.Add(Restrictions.Like("Message", "%" + searchCriteria.Message + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.MachineName))
                {
                    query.Add(Restrictions.Like("MachineName", "%" + searchCriteria.MachineName + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.UserId))
                {
                    query.Add(Restrictions.Like("UserId", "%" + searchCriteria.UserId + "%"));
                }
                if (searchCriteria.StartDate.HasValue)
                {
                    query.Add(Restrictions.Ge("Timestamp", searchCriteria.StartDate));
                }
                if (searchCriteria.EndDate.HasValue)
                {
                    query.Add(Restrictions.Le("Timestamp", searchCriteria.EndDate));
                }
                if (searchCriteria.IntegrationMessageId.HasValue)
                {
                    query.Add(Restrictions.Eq("IntegrationMessageId", searchCriteria.IntegrationMessageId));
                }
                eventLogDTO.EventLogList = query.SetFirstResult(Skip).SetMaxResults(Take).List<EventLog>();
            }
            using (new NHibernateSessionContext(SessionName))
            {
                ICriteria query = this.Session.CreateCriteria(typeof(EventLog));
                if (searchCriteria.Id.HasValue)
                {
                    query.Add(Restrictions.Eq("EventLogId", searchCriteria.Id.Value));
                }
                if (searchCriteria.Severity.HasValue)
                {
                    query.Add(Restrictions.Eq("SeverityId", searchCriteria.Severity));
                }
                if (searchCriteria.RequestId.HasValue)
                {
                    query.Add(Restrictions.Eq("RequestId", (searchCriteria.RequestId.Value)));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.BusinessId))
                {
                    query.Add(Restrictions.Eq("BusinessId", "%" + searchCriteria.BusinessId + "%"));
                }
                if (searchCriteria.BusinessIdType.HasValue)
                {
                    query.Add(Restrictions.Eq("BusinessIdTypeId", searchCriteria.BusinessIdType));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.Message))
                {
                    query.Add(Restrictions.Like("Message", "%" + searchCriteria.Message + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.MachineName))
                {
                    query.Add(Restrictions.Like("MachineName", "%" + searchCriteria.MachineName + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.UserId))
                {
                    query.Add(Restrictions.Like("UserId", "%" + searchCriteria.UserId + "%"));
                }
                if (searchCriteria.StartDate.HasValue)
                {
                    query.Add(Restrictions.Ge("Timestamp", searchCriteria.StartDate));
                }
                if (searchCriteria.EndDate.HasValue)
                {
                    query.Add(Restrictions.Le("Timestamp", searchCriteria.EndDate));
                }
                if (searchCriteria.IntegrationMessageId.HasValue)
                {
                    query.Add(Restrictions.Eq("IntegrationMessageId", searchCriteria.IntegrationMessageId));
                }
                eventLogDTO.Total = query.SetProjection(Projections.Count(Projections.Id())).FutureValue<int>().Value;
            }
            return eventLogDTO;
        }
        public IntegrationMessage GetIntegrationMessageDetail(int integrationMessageId)
        {
            IntegrationMessage result;
            using (new NHibernateSessionContext(SessionName))
            {
                result = Session.QueryOver<IntegrationMessage>().Where(m => m.IntegrationMessageId == integrationMessageId).SingleOrDefault();
            }
            return result;
        }
        public EventLog GetEventLogDetail(int EventLogId)
        {
            EventLog result;
            using (new NHibernateSessionContext(SessionName))
            {
                result = Session.QueryOver<EventLog>().Where(m => m.EventLogId == EventLogId).SingleOrDefault();
            }
            return result;
        }
        public void SaveEventLog(EventLogEntity eventLogInfo)
        {
            using (var transaction = new TransactionScope())
            {
                using (new NHibernateSessionContext(SessionName))
                {
                    Session.Save(eventLogInfo);
                }
                transaction.Complete();
            }

        }

    }
}
