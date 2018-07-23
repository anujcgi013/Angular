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
    public class OrganisationMap: ClassMapping<OrganisationInfo>
    {
        public OrganisationMap()
        {
            Table("[VuOrganisationInfo]");
            Schema("[dbo]");

            Id(x => x.OrganisationId,x => x.Generator(Generators.Assigned));
            Property(x => x.CDBPartyID);
            Property(x => x.OrgTypeId);
            Property(x => x.OrgType);
            Property(x => x.OrganisationNo);
            Property(x => x.LegalName);
            Property(x => x.CommonName);
            Property(x => x.VATRegNo);
            Property(x => x.Email);

            Property(x => x.ParmaNo);
            Property(x => x.Created);
            Property(x => x.Updated);
            Property(x => x.ResponsibleUnitTypeId);
            Property(x => x.ResponsibleUnitType);
            Property(x => x.DealerNumber);
            Property(x => x.ImporterNumber);
            Property(x => x.CustomerNo);

            Property(x => x.ParentOrganisationId);
            Property(x => x.ObjVersion);
            Property(x => x.A4DAddressId);
            Property(x => x.AddressText);
            Property(x => x.IsDeleted);
            Property(x => x.Timestamp);
            Property(x => x.MainPlace);
        }
    }
}
