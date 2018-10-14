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
    public class SystemEnumMap : ClassMapping<SystemEnum>
    {
        public SystemEnumMap()
        {
            Table("[SystemEnum]");
            Schema("[dbo]");
            Lazy(true);

            Id(x => x.Value, x => x.Generator(Generators.Assigned));
            Property(x => x.Name);
        }
    }
}
