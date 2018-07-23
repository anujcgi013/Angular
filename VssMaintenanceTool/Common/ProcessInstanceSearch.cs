using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ProcessInstanceSearch
    {
        public Guid? ProcessId { get; set; }
        public short? State { get; set; }
        public short? Status { get; set; }
        public string InterfaceName { get; set; }
        public string FIFOTag { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string FIFOTag2 { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
