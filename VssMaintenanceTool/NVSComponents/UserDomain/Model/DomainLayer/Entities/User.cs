using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Entities;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities
{
    [HasSelfValidation]
    public class User : GenericEntity<String>
    {
        public virtual string FirstName { get; set; }
        public virtual string BaldoUserId { get; set; }
    }
}
