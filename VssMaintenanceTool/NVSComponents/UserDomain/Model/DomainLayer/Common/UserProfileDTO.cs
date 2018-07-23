using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer.Common
{
    public class UserProfileDTO
    {
        public int Total { get; set; }
        public IList<UserProfileInfo> UserProfileInfoList { get; set; }
    }
}
