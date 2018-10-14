using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Core.Unity;
using Volvo.NVS.Persistence.NHibernate.SessionHandling;
using Volvo.VSS.LogDomain.DomainLayer.Common;
using Volvo.VSS.LogDomain.DomainLayer.Entities;
using Volvo.VSS.LogDomain.DomainLayer.RepositoryInterfaces;
using Volvo.VSS.LogDomain.ServiceLayer;

namespace Volvo.VSS.LogDomain.DomainLayer
{
    public class LogService : ILogService
    {
        
        protected IProcessLogRepository ProcessLogRepository { get; }
        protected IEventLogRepository EventLogRepository { get; }

        protected IMaintenanceInformationRepository MaintenanceInformationRepository { get; }
        public LogService()
        {
            ProcessLogRepository = Container.Resolve<IProcessLogRepository>();
            EventLogRepository = Container.Resolve<IEventLogRepository>();
            MaintenanceInformationRepository = Container.Resolve<IMaintenanceInformationRepository>();
        }
        public LogService(IProcessLogRepository processLogRepository, IEventLogRepository event_Log_Repository,IMaintenanceInformationRepository Maintenance_Info_Repository)
        {
            ProcessLogRepository = processLogRepository;
            EventLogRepository = event_Log_Repository;
            MaintenanceInformationRepository = Maintenance_Info_Repository;
        }

        public IList<ProcessLog> GetProcessLogDeatils()
        {
            using (new NHibernateSessionContext())
            {
                return ProcessLogRepository.FindAll(10);
            }
        }
        public IList<EventLog> GetEventLog(EventLogSearch searchCriteria, PageSettings pageSettings)
        {
            pageSettings.PageNumber = (pageSettings.ItemsPerPage == 0) ? 1 : pageSettings.ItemsPerPage;
            int itemsToSkip = (pageSettings.PageNumber - 1) * pageSettings.ItemsPerPage;
            return EventLogRepository.GetEventLog(searchCriteria, pageSettings.ItemsPerPage, itemsToSkip);
        }

        public IntegrationMessageDTO GetIntegrationMessage(IntegrationMessageSearch searchCriteria)
        {
                return EventLogRepository.GetIntegrationMessage(searchCriteria);
        }

        public IList<EventLog> GetEventLogList(PageSettings pageSetting)
        {
            pageSetting.PageNumber = (pageSetting.ItemsPerPage == 0) ? 1 : pageSetting.ItemsPerPage;
            int itemsToSkip = (pageSetting.PageNumber - 1) * pageSetting.ItemsPerPage;
            return EventLogRepository.GetEventLogList(pageSetting.ItemsPerPage, itemsToSkip);
        }

        public IList<MaintenanceInformation> GetMaintenanceInformation(DateTime startdate, DateTime enddate, string header, string message)
        {
            using (new NHibernateSessionContext())
            {
                return MaintenanceInformationRepository.GetMaintenanceInformation(startdate, enddate, header, message);
            }
        }

        public MaintenanceInformationDTO GetMaintenanceInformation(MaintenanceInformationSearch searchCriteria)
        {
                return MaintenanceInformationRepository.GetMaintenanceInformation(searchCriteria);
        }
        public MaintenanceInformation GetMaintenanceInformationDetail(int MaintenanceInformationId)
        {
            return MaintenanceInformationRepository.GetMaintenanceInformationDetail(MaintenanceInformationId);
        }
        public IList<MaintenanceInformation> GetMaintenanceInformation(string header, string message)
        {
            using (new NHibernateSessionContext())
            {
                return MaintenanceInformationRepository.GetMaintenanceInformation(header, message);
            }
        }

        public void SaveMaintenanceMsg(MaintenanceInformation maintenanceinfo)
        {

            MaintenanceInformationRepository.SaveMaintenanceMsg(maintenanceinfo);
        }

        public void UpdateMaintenanceMsg(MaintenanceInformation maintenanceinfo)
        {

            MaintenanceInformationRepository.UpdateMaintenanceMsg(maintenanceinfo);
        }

        public IList<SystemEnum> GetSystemEnumList()
        {
            return EventLogRepository.GetSystemEnumList();
        }

        public IList<IntegrationMessageTypeEnum> GetIntegrationMessageTypeEnumList()
        {
            return EventLogRepository.GetIntegrationMessageTypeEnumList();
        }

        public IList<IntegrationMessageStatusEnum> GetIntegrationMessageStatusEnumList()
        {
            return EventLogRepository.GetIntegrationMessageStatusEnumList();
        }

        public IList<BusinessIdTypeEnum> GetBusinessIdTypeEnumList()
        {
            return EventLogRepository.GetBusinessIdTypeEnumList();
        }

        public IList<SeverityTypeEnum> GetSeverityTypeEnumList()
        {
            return EventLogRepository.GetSeverityTypeEnumList();
        }
        public EventLogDTO GetEventLogs(EventLogSearch searchCriteria)
        {
            return EventLogRepository.GetEventLogs(searchCriteria);
        }
        public IntegrationMessage GetIntegrationMessageDetail(int integrationMessageId)
        {
            return EventLogRepository.GetIntegrationMessageDetail(integrationMessageId);
        }
        public EventLog GetEventLogDetail(int EventLogId)
        {
            return EventLogRepository.GetEventLogDetail(EventLogId);
        }


        public void SaveEventLog(EventLogEntity eventLogInfo)
        {
            EventLogRepository.SaveEventLog(eventLogInfo);
        }
    }
}
