using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer.Common
{
    [Serializable()]
    public class UserOrganisationDTO
    {
        public int Total { get; set; }
        public IList<UserOrganisationInfo> UserOrganisationInfoList { get; set; }
    }
}
