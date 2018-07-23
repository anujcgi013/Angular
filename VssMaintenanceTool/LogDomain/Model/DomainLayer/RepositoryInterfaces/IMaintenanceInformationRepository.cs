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
   public interface IMaintenanceInformationRepository : IGenericRepository<MaintenanceInformation, string>
    {

        IList<MaintenanceInformation> GetMaintenanceInformation(DateTime startDate , DateTime enddate, string header, string message );
        IList<MaintenanceInformation> GetMaintenanceInformation(string header, string message);
        MaintenanceInformationDTO GetMaintenanceInformation(MaintenanceInformationSearch searchCriteria);
        MaintenanceInformation GetMaintenanceInformationDetail(int searchCriteria);
        void SaveMaintenanceMsg(MaintenanceInformation MaintenanceInfo);
        void UpdateMaintenanceMsg(MaintenanceInformation MaintenanceInfo);
    }
}
