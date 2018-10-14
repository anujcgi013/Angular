using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.VSS.LogDomain.DomainLayer.Common;
using Volvo.VSS.LogDomain.DomainLayer.Entities;

namespace Volvo.VSS.LogDomain.ServiceLayer
{
    public interface ILogService
    {
        IList<ProcessLog> GetProcessLogDeatils();
        IList<EventLog> GetEventLog(EventLogSearch searchCriteria, PageSettings pageSettings);
        IntegrationMessageDTO GetIntegrationMessage(IntegrationMessageSearch search);
        IList<EventLog> GetEventLogList(PageSettings pageSetting);
        IList<MaintenanceInformation> GetMaintenanceInformation(DateTime startDate, DateTime enddate, string header, string message);
        MaintenanceInformationDTO GetMaintenanceInformation(MaintenanceInformationSearch searchCriteria);
        MaintenanceInformation GetMaintenanceInformationDetail(int MaintenanceInformationId);
        IList<MaintenanceInformation> GetMaintenanceInformation(string header, string message);
        void SaveMaintenanceMsg(MaintenanceInformation content);
        void UpdateMaintenanceMsg(MaintenanceInformation content);
        IList<SystemEnum> GetSystemEnumList();
        IList<IntegrationMessageTypeEnum> GetIntegrationMessageTypeEnumList();
        IList<IntegrationMessageStatusEnum> GetIntegrationMessageStatusEnumList();
        IList<SeverityTypeEnum> GetSeverityTypeEnumList();
        IList<BusinessIdTypeEnum> GetBusinessIdTypeEnumList();
        EventLogDTO GetEventLogs(EventLogSearch searchCriteria);
        IntegrationMessage GetIntegrationMessageDetail(int integrationMessageId);
        EventLog GetEventLogDetail(int EventLogId);
        void SaveEventLog(EventLogEntity eventLogInfo);
    }
}
