using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Entities;

namespace Volvo.VSS.ProcessDomain.DomainLayer.Entities
{
    public class ProcessInstance : GenericEntity
    {
        public virtual Guid ProcessId { get; set; }
        public virtual short State { get; set; }
        public virtual short StatusId { get; set; }
        public virtual string Status { get; set; }
        public virtual string InterfaceNameId { get; set; }
        public virtual string InterfaceName { get; set; }
        public virtual string FIFOTag { get; set; }
        //public virtual DateTime CreatedAt { get; set; }
        //public virtual DateTime UpdatedAt { get; set; }
        private DateTime createdAt;
        public virtual DateTime CreatedAt
        {
            get { return this.createdAt; }
            set
            {
                this.createdAt = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }

        private DateTime updatedAt;
        public virtual DateTime UpdatedAt
        {
            get { return this.updatedAt; }
            set
            {
                this.updatedAt = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }
        public virtual string FIFOTag2 { get; set; }
    }
}
