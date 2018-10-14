using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Entities;

namespace Volvo.VSS.LogDomain.DomainLayer.Entities
{
    public class IntegrationMessage: GenericEntity
    {
        public virtual int IntegrationMessageId { get; set; }
        public virtual int MessageTypeId { get; set; }
        public virtual string MessageType { get; set; }
        public virtual int StatusId { get; set; }
        public virtual string Status { get; set; }
        public virtual int SystemId { get; set; }
        public virtual string System { get; set; }
        public virtual string Message { get; set; }

        private  DateTime timestamp;
        public virtual DateTime TimeStamp
        {
            get { return this.timestamp; }
            set
            {
                this.timestamp = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }
    }
}
