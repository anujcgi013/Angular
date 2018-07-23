using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.Repositories;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Common;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;


namespace Volvo.VSSMaintenance.UserDomain.ServiceLayer
{
    public interface IGDPRService
    {
        GDPRDTO GetGDPRInfoDetail(GDPRInfoSearch searchCriteria);
        List<GDPRInfo> GetGDPRInfo(GDPRInfoSearch searchCriteria);
    }
}
