using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Entities;

namespace Volvo.VSS.LogDomain.DomainLayer.Entities
{
    public class EventLog : GenericEntity
    {
        public virtual int EventLogId { get; set; }
        public virtual string Severity { get; set; }
        public virtual int SeverityId { get; set; }
        public virtual Guid RequestId { get; set; }
        public virtual string BusinessId { get; set; }
        public virtual string BusinessIdType { get; set; }
        public virtual int BusinessIdTypeId { get; set; }
        public virtual string Message { get; set; }
        public virtual string MachineName { get; set; }
        public virtual string UserId { get; set; }

        private DateTime timestamp;
        public virtual DateTime Timestamp
        {
            get { return this.timestamp; }
            set
            {
                this.timestamp = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }
        public virtual int? IntegrationMessageId { get; set; }
    }
}
