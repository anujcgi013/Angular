using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Entities;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities
{
    public class OrganisationInfo: GenericEntity
    {
        public virtual Guid OrganisationId { get; set; }
        public virtual string CDBPartyID { get; set; }
        public virtual int OrgTypeId { get; set; }
        public virtual string OrgType { get; set; }
        public virtual string OrganisationNo { get; set; }
        public virtual string LegalName { get; set; }
        public virtual string CommonName { get; set; }
        public virtual string VATRegNo { get; set; }
        public virtual string Email { get; set; }
        public virtual string ParmaNo { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Updated { get; set; }
        public virtual int ResponsibleUnitTypeId { get; set; }
        public virtual string ResponsibleUnitType { get; set; }
        public virtual string DealerNumber { get; set; }
        public virtual string ImporterNumber { get; set; }
        public virtual string CustomerNo { get; set; }
        public virtual Guid ParentOrganisationId { get; set; }
        public virtual int ObjVersion { get; set; }
        public virtual string A4DAddressId { get; set; }
        public virtual string AddressText { get; set; }
        public virtual int IsDeleted { get; set; }
        public virtual DateTime Timestamp { get; set; }
        public virtual string MainPlace { get; set; }
    }
}
