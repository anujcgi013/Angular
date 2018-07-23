using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Entities;
using Volvo.VSS.LogDomain.DomainLayer.Entities;

namespace Volvo.VSS.LogDomain.InfrastructureLayer.Repositories
{
    public class SeverityTypeEnumMap:ClassMapping<SeverityTypeEnum>
    {
        public SeverityTypeEnumMap()
        {
            Table("[SeverityTypeEnum]");
            Schema("[dbo]");
            Lazy(true);

            Id(x => x.Value, x => x.Generator(Generators.Assigned));
            Property(x => x.Name);
        }
    }
}
