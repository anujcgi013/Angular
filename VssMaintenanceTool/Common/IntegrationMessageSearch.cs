using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class IntegrationMessageSearch
    {
        public int? Id { get; set; }
        public int? MessageType { get; set; }
        public int? Status { get; set; }
        public int? System { get; set; }
        public string Message { get; set; }
        public DateTime? StartTimeStamp { get; set; }
        public DateTime? EndTimeStamp { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

    }
}
