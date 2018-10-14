using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.VSS.ProcessDomain.DomainLayer.Entities;

namespace Volvo.VSS.ProcessDomain.DomainLayer.Common
{
    [Serializable()]
    public class ProcessInstanceDTO
    {
        public int Total { get; set; }
        public IList<ProcessInstance> ProcessInstanceList { get; set; }
             
    }
}
