using System;
using System.Collections.Generic;
using Volvo.NVS.Core.Unity;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.RepositoryInterfaces;
using Volvo.VSSMaintenance.UserDomain.ServiceLayer;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer
{
   public class MarketService : IMarketService
    {
        protected IMarketRepository MarketRepository { get; }

        public MarketService() {

            MarketRepository = Container.Resolve<IMarketRepository>();
        }
        public MarketService(IMarketRepository marketRepository)
        {
            MarketRepository = marketRepository;
        }
        public IList<Market> GetMarketIdAndDescription()
        {
                       
                return MarketRepository.GetMarketIdAndDescription();            
        }

        public void SavecalenderforMarket(Market marketObj)
        {
             MarketRepository.SavecalenderforMarket(marketObj);
            
        }

        public Market CheckCalenderExistsForMarket(Guid marketid)
        {
            return MarketRepository.CheckCalenderExistsForMarket(marketid);

        }
        

    }
   
}
