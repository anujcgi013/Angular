using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer.Common
{
    public class GDPRDTO
    {
        public IList<GDPRInfo> GDPRInfoList { get; set; }
    }
}
