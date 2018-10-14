using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class EventLogSearch
    {
        public int? Id { get; set; }
        public int? Severity { get; set; }
        public Guid? RequestId { get; set; }
        public string BusinessId { get; set; }
        public int? BusinessIdType { get; set; }
        public string Message { get; set; }
        public string MachineName { get; set; }
        public string UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? IntegrationMessageId { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
