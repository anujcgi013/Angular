using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.VSS.LogDomain.DomainLayer.Entities;

namespace Volvo.VSS.LogDomain.InfrastructureLayer.Repositories
{
    public class ProcessLogMap : ClassMapping<ProcessLog>
    {
        public ProcessLogMap()
        {
            Table("[PROCESSDETAILS]");
            Schema("[dbo]");
            Lazy(true);
            Id(x => x.ProcessId, x => x.Generator(Generators.Assigned));
            Property(x => x.InterfaceName);
            Property(x => x.Status);
            Property(x => x.FIFOTag);
            Property(x => x.FIFOTag2);
            Property(x => x.CreatedAt);
            Property(x => x.UpdatedAt);
            Property(x => x.ErrorText);
            Property(x => x.RequestId);
            Property(x => x.OMOrderID);
            Property(x => x.OMBuyerPartyId);
            Property(x => x.OMCustomerPartyId);
            Property(x => x.OriginalOrderDate);
        }
    }
}
