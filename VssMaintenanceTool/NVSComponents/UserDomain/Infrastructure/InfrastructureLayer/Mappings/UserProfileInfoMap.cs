using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;

namespace Volvo.VSSMaintenance.UserDomain.InfrastructureLayer.Mappings
{
    public class UserProfileInfoMap: ClassMapping<UserProfileInfo>
    {
        public UserProfileInfoMap()
        {
            Table("[VuUserProfileInfo]");
            Schema("[dbo]");

            Id(x => x.UserProfileId);
            Property(x => x.ProfileId);
            Property(x => x.Profile);
            Property(x => x.UserId);
            Property(x => x.BaldoUserId);
            Property(x => x.FirstName);
            Property(x => x.SurName);
        }
    }
}
