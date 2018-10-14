using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;

namespace Volvo.VSSMaintenance.UserDomain.InfrastructureLayer.Mappings
{
    class UserOrganisationInfoMap: ClassMapping<UserOrganisationInfo>
    {
        public UserOrganisationInfoMap()
        {
            Table("[VuUserOrganisationInfo]");
            Schema("[dbo]");
            Id(x => x.Id);
            Property(x => x.FirstName);
            Property(x => x.SurName);
            Property(x => x.UserId);
            Property(x => x.BaldoUserId);
            Property(x => x.OrganisationId);
            Property(x => x.CDBPartyId);
            Property(x => x.RUSettingsId);
            Property(x => x.LegalName);
            Property(x => x.CommonName);
        }
    }
}
