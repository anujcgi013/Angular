using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Entities;


namespace Volvo.VSS.LogDomain.DomainLayer.Entities
{
    public class MaintenanceInformation : GenericEntity
    {
        //public virtual int Id { get; set; }
        public virtual string Header { get; set; }
        public virtual string Message { get; set; }
        public virtual string CreatedBy { get; set; }
        private DateTime created;
        public virtual DateTime Created
        {
            get { return this.created; }
            set
            {
                this.created = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }       

        private DateTime validFrom;
        public virtual DateTime ValidFrom
        {
            get { return this.validFrom; }
            set
            {
                this.validFrom = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }

        private DateTime validTo;
        public virtual DateTime ValidTo
        {
            get { return this.validTo; }
            set
            {
                this.validTo = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }        
        public MaintenanceInformation()
        {
            Created = DateTime.UtcNow;
        }
    }

}
