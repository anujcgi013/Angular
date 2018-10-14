using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.Repositories;
using Volvo.VSS.LogDomain.DomainLayer.Common;
using Volvo.VSS.LogDomain.DomainLayer.Entities;

namespace Volvo.VSS.LogDomain.DomainLayer.RepositoryInterfaces
{
    public interface IEventLogRepository:IGenericRepository<EventLog, string>
    {
        IList<EventLog> GetEventLog(EventLogSearch searchCriteria, int take, int skip);
        IntegrationMessageDTO GetIntegrationMessage(IntegrationMessageSearch search);
        IList<EventLog> GetEventLogList(int itemsPerPage, int itemsToSkip);
        IList<SystemEnum> GetSystemEnumList();
        IList<IntegrationMessageTypeEnum> GetIntegrationMessageTypeEnumList();
        IList<IntegrationMessageStatusEnum> GetIntegrationMessageStatusEnumList();
        IList<BusinessIdTypeEnum> GetBusinessIdTypeEnumList();
        IList<SeverityTypeEnum> GetSeverityTypeEnumList();
        EventLogDTO GetEventLogs(EventLogSearch searchCriteria);
        IntegrationMessage GetIntegrationMessageDetail(int integrationMessageId);
        EventLog GetEventLogDetail(int EventLogId);
        void SaveEventLog(EventLogEntity eventLogInfo);
    }
}
