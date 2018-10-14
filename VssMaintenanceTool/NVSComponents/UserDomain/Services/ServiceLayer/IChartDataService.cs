using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;

namespace Volvo.VSSMaintenance.UserDomain.ServiceLayer
{
    public interface IChartDataService
    {
        IList<ChartData> GetChartData();
    }
}
