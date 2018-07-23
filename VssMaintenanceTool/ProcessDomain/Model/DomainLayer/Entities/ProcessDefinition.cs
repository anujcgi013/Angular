using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Entities;

namespace Volvo.VSS.ProcessDomain.DomainLayer.Entities
{
    public class ProcessDefinition: GenericEntity
    {
        public virtual string InterfaceName { get; set; }
        public virtual string Name { get; set; }
    }
}
