using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Entities;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities
{
    public class GDPRInfo : GenericEntity
    {
        public virtual string PersonType { get; set; }
        public virtual string UserID { get; set; }
        public virtual string Salutation { get; set; }
        public virtual string Title { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string SurName { get; set; }
        public virtual string Gender { get; set; }
        public virtual string Profession { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string Note { get; set; }
        public virtual string Fax { get; set; }
        public virtual byte[] Signature { get; set; }
    }
}
