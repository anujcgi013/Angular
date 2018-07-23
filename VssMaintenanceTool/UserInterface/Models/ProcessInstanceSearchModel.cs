using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Volvo.MaintenanceTool.UserInterface.Models
{
    public class ProcessInstanceSearchModel
    {
        [DisplayName("Process Id")]
        public Guid? ProcessId { get; set; }

        [DisplayName("State")]
        public short? State { get; set; }

        [DisplayName("Status")]
        public short? Status { get; set; }
        public IList<SelectListItem> StatusList { get; set; }

        [DisplayName("Interface Name")]
        public string InterfaceName { get; set; }
        public IList<SelectListItem> InterfaceNameList { get; set; }

        [DisplayName("FIFO Tag")]
        public string FIFOTag { get; set; }

        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }

        [DisplayName("FIFO Tag2")]
        public string FIFOTag2 { get; set; }
    }
}