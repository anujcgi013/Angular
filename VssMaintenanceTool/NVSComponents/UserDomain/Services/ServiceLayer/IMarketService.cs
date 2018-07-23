using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;

namespace Volvo.VSSMaintenance.UserDomain.ServiceLayer
{
    public interface IMarketService
    {
        IList<Market> GetMarketIdAndDescription();
        void SavecalenderforMarket(Market marketobj);
        Market CheckCalenderExistsForMarket(Guid marketid);
    }
    
}
