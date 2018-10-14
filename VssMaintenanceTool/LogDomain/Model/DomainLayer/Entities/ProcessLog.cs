using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Entities;

namespace Volvo.VSS.LogDomain.DomainLayer.Entities
{
    public  class ProcessLog : GenericEntity
    {
        public virtual Guid ProcessId { get; set; }
        public virtual string InterfaceName { get; set; }
        public virtual short Status { get; set; }
        public virtual string FIFOTag { get; set; }
        public virtual string FIFOTag2 { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime UpdatedAt { get; set; }
        public virtual string ErrorText { get; set; }
        public virtual Guid RequestId { get; set; }
        public virtual string OMOrderID { get; set; }
        public virtual string OMBuyerPartyId { get; set; }
        public virtual string OMCustomerPartyId { get; set; }
        public virtual string OriginalOrderDate { get; set; }
    }
}
