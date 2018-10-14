using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Entities;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities
{
    public class UserProfileInfo: GenericEntity
    {
        public virtual Guid UserProfileId { get; set; }
        public virtual int ProfileId { get; set; }
        public virtual string Profile { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual string BaldoUserId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string SurName { get; set; }

    }
}
