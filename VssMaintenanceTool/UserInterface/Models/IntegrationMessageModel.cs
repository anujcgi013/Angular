using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Volvo.MaintenanceTool.UserInterface.Models
{
    public class IntegrationMessageModel
    {
        [DisplayName("Id")]
        public  int Id { get; set; }

        [DisplayName("Message Type")]
        public string MessageType { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("System")]
        public string System { get; set; }

        [DisplayName("Message")]
        public string Message { get; set; }

       
        private DateTime timestamp;
        [DisplayName("Timestamp")]
        public DateTime TimeStamp
        {
            get { return this.timestamp; }
            set
            {
                this.timestamp = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }
    }
}