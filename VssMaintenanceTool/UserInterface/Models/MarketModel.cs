using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Volvo.MaintenanceTool.UserInterface.Models
{
    public class MarketModel
    {
        public  string MarketId { get; set; }
        public  string Description { get; set; }
        public IList<CalendarModel> cal { get; set; } = null;
    }
}