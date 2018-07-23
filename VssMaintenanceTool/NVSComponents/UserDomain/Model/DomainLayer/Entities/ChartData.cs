using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Entities;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities
{
    public class ChartData : GenericEntity
    {
        //private DateTime _myDate;
        public DateTime Created { get; set; }
        public int NumOfQuotes { get; set; }
        public int NumOfOrders { get; set; }
    }
}
