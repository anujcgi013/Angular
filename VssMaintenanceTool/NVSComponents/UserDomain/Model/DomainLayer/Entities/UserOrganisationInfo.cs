using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Entities;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities
{
    public class UserOrganisationInfo: GenericEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string BaldoUserId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string SurName { get; set; }
        public virtual Guid? UserId { get; set; }
        public virtual Guid? OrganisationId { get; set; }
        public virtual Guid? RUSettingsId { get; set; }
        public virtual string CDBPartyId { get; set; }
        public virtual string CommonName { get; set; }
        public virtual string LegalName { get; set; }
    }
}
