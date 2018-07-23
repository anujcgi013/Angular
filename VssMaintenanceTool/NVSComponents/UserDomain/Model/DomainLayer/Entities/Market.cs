using System;
using System.Collections.Generic;
using Volvo.NVS.Persistence.NHibernate.Entities;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities
{
    public class Market : GenericEntity<Guid>
    {
        public virtual Guid Id { get; set; }
        public virtual string MarketId { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<Calendar> Calendars { get; set; }

    }
}
