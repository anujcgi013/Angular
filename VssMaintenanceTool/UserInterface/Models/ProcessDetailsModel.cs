using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Volvo.MaintenanceTool.UserInterface.Models
{
    public class ProcessDetailsModel
    {
        public Guid ProcessId { get; set; }
        public string InterfaceName { get; set; }
        public short Status { get; set; }
        public string FIFOTag { get; set; }
        public string FIFOTag2 { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ErrorText { get; set; }
        public Guid RequestId { get; set; }
        public string OMOrderID { get; set; }
        public string OMBuyerPartyId { get; set; }
        public string OMCustomerPartyId { get; set; }
        public string OriginalOrderDate { get; set; }

    }
}