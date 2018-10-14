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
    public class IntegrationMessageMap: ClassMapping<IntegrationMessage>
    {
        public IntegrationMessageMap()
        {
            Table("[VuIntegrationMessage]");
            Schema("[dbo]");

            Id(x=>x.IntegrationMessageId);
            Property(x => x.MessageType);
            Property(x => x.MessageTypeId);
            Property(x => x.Status);
            Property(x => x.System);
            Property(x => x.StatusId);
            Property(x => x.SystemId);
            Property(x => x.Message);
            Property(x => x.TimeStamp);
        }
    }
}
