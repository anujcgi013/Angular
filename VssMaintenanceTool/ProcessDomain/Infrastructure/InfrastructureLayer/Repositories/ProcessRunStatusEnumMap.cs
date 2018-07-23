using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.VSS.ProcessDomain.DomainLayer.Entities;

namespace Volvo.VSS.ProcessDomain.InfrastructureLayer.Repositories
{
    public class ProcessRunStatusEnumMap: ClassMapping<ProcessRunStatusEnum>
    {
        public ProcessRunStatusEnumMap()
        {
            Table("[ProcessRunStatusEnum]");
            Schema("[Process]");
            Lazy(true);

            Id(x => x.Value, x => x.Generator(Generators.Assigned));
            Property(x => x.Name);
        }
    }
}
