using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Volvo.MaintenanceTool.UserInterface.Models
{
    public class IntegrationMessageSearchModel
    {
        [DisplayName("Id")]
        public int? Id { get; set; }

        [DisplayName("Message Type")]
        public int? MessageType { get; set; }
        public IList<SelectListItem> MessageTypeEnumList { get; set; }

        [DisplayName("Status")]
        public  int? Status { get; set; }
        public IList<SelectListItem> StatusEnumList { get; set; }

        [DisplayName("System")]
        public int? System { get; set; }
        public IList<SelectListItem> SystemEnumList { get; set; }

        [DisplayName("Message")]
        public string Message { get; set; }

        [DisplayName("Start TimeStamp")]
        public DateTime? StartTimeStamp { get; set; }

        [DisplayName("End TimeStamp")]
        public DateTime? EndTimeStamp { get; set; }
    }
}