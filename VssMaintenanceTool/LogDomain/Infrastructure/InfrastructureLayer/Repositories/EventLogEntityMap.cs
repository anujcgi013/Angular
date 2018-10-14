using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Volvo.VSS.LogDomain.DomainLayer.Entities;

namespace Volvo.VSS.LogDomain.InfrastructureLayer.Repositories
{
    public class EventLogEntityMap : ClassMapping<EventLogEntity>
    {
        public EventLogEntityMap()
        {
            Table("[EventLog]");
            Schema("[dbo]");
            
            Id(x => x.Id, x => x.Generator(Generators.Identity));
            Property(x => x.Severity);
            Property(x => x.RequestId);
            Property(x => x.BusinessId);
            Property(x => x.BusinessIdType);
            Property(x => x.Title);
            Property(x => x.Message);
            Property(x => x.BusinessAction);
            Property(x => x.MachineName);
            Property(x => x.UserId);
            Property(x => x.Timestamp);
            Property(x => x.ProcessName);
            Property(x => x.IntegrationMessageId);
        }
    }
}
