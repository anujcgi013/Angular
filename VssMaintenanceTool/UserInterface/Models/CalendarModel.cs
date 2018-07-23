using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Volvo.MaintenanceTool.UserInterface.Models
{
    public class CalendarModel
    {
        public  string MarketId { get; set; }
        public  DateTime Date { get; set; }
        public  bool isWeekday { get; set; }
        public  bool isHoliday { get; set; }
        public  string HolidayDescription { get; set; }
        public  string MonthName { get; set; }
        public  string DayName { get; set; }

    }
}