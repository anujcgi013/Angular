using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Volvo.MaintenanceTool.UserInterface.Models
{
    public class EventLogSearchModel
    {
        [DisplayName("Id")]
        public int? Id { get; set; }

        [DisplayName("Severity")]
        public int? Severity { get; set; }
        public IList<SelectListItem> SeverityList { get; set; }

        [DisplayName("Request Id")]
        public Guid? RequestId { get; set; }

        [DisplayName("Business Id")]
        public string BusinessId { get; set; }

        [DisplayName("Business Type Id")]
        public int? BusinessTypeId { get; set; }
        public IList<SelectListItem> BusinessTypeIdList { get; set; }

        [DisplayName("Message")]
        public string Message { get; set; }

        [DisplayName("Machine Name")]
        public string MachineName { get; set; }

        [DisplayName("User Id")]
        public string UserId { get; set; }

        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }

        [DisplayName("Integration Message Id")]
        public int? IntegrationMessageId { get; set; }
        public virtual IEnumerable<EventLogModel> EventLogModelList { get; set; }
    }
}