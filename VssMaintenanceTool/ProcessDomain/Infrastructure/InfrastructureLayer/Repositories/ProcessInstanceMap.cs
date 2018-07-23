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
    public class ProcessInstanceMap : ClassMapping<ProcessInstance>
    {
        public ProcessInstanceMap()
        {
            Table("[VuProcessInstance]");
            Schema("[dbo]");

            Id(x => x.ProcessId, x => x.Generator(Generators.Assigned));
            Property(x => x.State);
            Property(x => x.Status);
            Property(x => x.StatusId);
            Property(x => x.InterfaceName);
            Property(x => x.InterfaceNameId);
            Property(x => x.FIFOTag);
            Property(x => x.CreatedAt);
            Property(x => x.UpdatedAt);
            Property(x => x.FIFOTag2);
        }
    }
}
