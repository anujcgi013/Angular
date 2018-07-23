using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Entities;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;

namespace Volvo.VSSMaintenance.UserDomain.InfrastructureLayer.Mappings
{
    class GDPRInfoMap : ClassMapping<GDPRInfo>
    {
        public GDPRInfoMap()
        {
            //Table("[VuUserOrganisationInfo]");
            //Schema("[dbo]");
            //Id(x => x.Id);
            Property(x => x.PersonType);
            Property(x => x.UserID);
            Property(x => x.Salutation);
            Property(x => x.Title);
            Property(x => x.FirstName);
            Property(x => x.MiddleName);
            Property(x => x.SurName);
            Property(x => x.Gender);
            Property(x => x.Profession);
            Property(x => x.Email);
            Property(x => x.Phone);
            Property(x => x.Mobile);
            Property(x => x.Note);
            Property(x => x.Fax);
            Property(x => x.Signature);
        }
    }
}
