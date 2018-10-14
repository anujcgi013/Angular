using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Volvo.MaintenanceTool.UserInterface.Models
{
    public class MaintenanceInformationSearchModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Title")]
        public string Header { get; set; }
        [DisplayName("Message")]
        public string Message { get; set; }
        [DisplayName("Valid From")]
        public DateTime? ValidFrom { get; set; }
        [DisplayName("Valid To")]
        public DateTime? ValidTo { get; set; }
        [DisplayName("Created By")]
        public string CreatedBy { get; set; }
        [DisplayName("Created")]
        public DateTime Created { get; set; }
    }
}