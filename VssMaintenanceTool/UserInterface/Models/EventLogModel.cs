using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;

namespace Volvo.MaintenanceTool.UserInterface.Models
{
    public class EventLogModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Severity")]
        public string Severity { get; set; }

        [DisplayName("Request Id")]
        public Guid RequestId { get; set; }

        [DisplayName("Business Id")]
        public string BusinessId { get; set; }

        [DisplayName("BusinessId Type")]
        public string BusinessIdType { get; set; }

        [DisplayName("Message")]
        public string Message { get; set; }

        [DisplayName("Machine Name")]
        public string MachineName { get; set; }

        [DisplayName("User Id")]
        public string UserId { get; set; }

        private DateTime timestamp;
        [DisplayName("Timestamp")]
        public DateTime Timestamp
        {
            get { return this.timestamp; }
            set
            {
                this.timestamp = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }

        [DisplayName("Integration Message Id")]
        public int? IntegrationMessageId { get; set; }
    }
}