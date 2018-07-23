using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MaintenanceInformationSearch
    {
        public string Header { get; set; }
        public string Message { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
