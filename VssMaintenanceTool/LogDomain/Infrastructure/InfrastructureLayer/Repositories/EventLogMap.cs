using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.VSS.LogDomain.DomainLayer.Entities;
using static NHibernate.Bytecode.CodeDom.BytecodeProviderImpl;

namespace Volvo.VSS.LogDomain.InfrastructureLayer.Repositories
{
    public class EventLogMap : ClassMapping<EventLog>
    {
        public EventLogMap()
        {
            Table("[VuEventLog]");
            Schema("[dbo]");

            Id(x => x.EventLogId, x => x.Generator(Generators.Assigned));
            Property(x => x.Severity);
            Property(x => x.SeverityId);
            Property(x => x.RequestId);
            Property(x => x.BusinessId);
            Property(x => x.BusinessIdType);
            Property(x => x.BusinessIdTypeId);
            Property(x => x.Message);
            Property(x => x.MachineName);
            Property(x => x.UserId);
            Property(x => x.Timestamp);
            Property(x => x.IntegrationMessageId);
        }
    }
}
