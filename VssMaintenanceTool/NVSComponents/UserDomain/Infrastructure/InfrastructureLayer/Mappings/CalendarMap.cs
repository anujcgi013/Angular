using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;

namespace Volvo.VSSMaintenance.UserDomain.InfrastructureLayer.Mappings
{
    public class CalendarMap : ClassMapping<Calendar>
    {
        public CalendarMap()
        {
            Table("[Calendar]");
            Schema("[dbo]");
            Lazy(true);

            Id(x => x.Id, x => x.Generator(Generators.Guid));
            Property(x => x.MarketId);
            Property(x => x.Date);
            Property(x => x.isHoliday);
            Property(x => x.isWeekday);
            Property(x => x.HolidayDescription);
            Property(x => x.MonthName);
            Property(x => x.DayName);

        }
    }
}
