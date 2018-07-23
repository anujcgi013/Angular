using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.VSS.LogDomain.DomainLayer.Entities;

namespace Volvo.VSS.LogDomain.DomainLayer.Common
{
    public class MaintenanceInformationDTO
    {
        public int Total { get; set; }
        public IList<MaintenanceInformation> MaintenanceInformationlist { get; set; }
    }
}
