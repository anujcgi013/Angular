using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volvo.VSS.LogDomain.DomainLayer.Entities
{
   public class EventLogEntity
    {
        public virtual int Id { get; set; }
        public virtual int Severity { get; set; }
        public virtual Guid RequestId { get; set; }
        public virtual string BusinessId { get; set; }
        public virtual int BusinessIdType { get; set; }
        public virtual int Title { get; set; }
        public virtual string Message { get; set; }
        public virtual string  BusinessAction { get; set; }
        public virtual string MachineName { get; set; }
        public virtual string UserId { get; set; }
        public virtual DateTime Timestamp { get; set; }
        public virtual string  ProcessName { get; set; }
        public virtual int? IntegrationMessageId { get; set; }
        public virtual string Source { get; set; }



    }
}
