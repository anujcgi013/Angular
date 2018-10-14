using System;
using Volvo.NVS.Persistence.NHibernate.Entities;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities
{
    public class Calendar : GenericEntity
    {
        public virtual Guid Id { get; set; }
        public virtual Guid MarketId { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual bool isWeekday { get; set; }
        public virtual bool isHoliday { get; set; }
        public virtual string HolidayDescription { get; set; }
        public virtual string MonthName { get; set; }
        public virtual string DayName { get; set; }

    }
}
