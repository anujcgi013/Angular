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
    public class ProcessDefinitionMap: ClassMapping<ProcessDefinition>
    {
        public ProcessDefinitionMap()
        {
            Table("[ProcessDefinition]");
            Schema("[Process]");
            Lazy(true);

            Id(x => x.InterfaceName, x => x.Generator(Generators.Assigned));
            Property(x => x.Name);
        }
    }
}
