using NHibernate.Mapping;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Volvo.NVS.Persistence.NHibernate.Repositories;
using Volvo.NVS.Persistence.NHibernate.SessionHandling;
using Volvo.NVS.Persistence.Specifications;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.RepositoryInterfaces;

namespace Volvo.VSSMaintenance.UserDomain.InfrastructureLayer.Repositories
{
    public class MarketRepository : GenericRepository<Market, string>, IMarketRepository
    {

        public MarketRepository()
        {
        }
        public MarketRepository(string name) : base(name)
        {
        }

        /// <summary>
        ///  Get All Market Id's,Market Description's 
        /// </summary>
        /// <returns></returns>
        public IList<Market> GetMarketIdAndDescription()
        {
            using (new NHibernateSessionContext(SessionName))
            { 
            using (var trans = new TransactionScope())
            {
                Market result = null;
                IList<Market> marketList = Session.QueryOver<Market>()
               .SelectList(list => list
               .Select(pr => pr.Id).WithAlias(() => result.Id)
               .Select(pr => pr.MarketId).WithAlias(() => result.MarketId)
               .Select(pr => pr.Description).WithAlias(() => result.Description))
               .TransformUsing(Transformers.AliasToBean<Market>())
               .List<Market>();
                return marketList;
            } 
            }
        }

        /// <summary>
        ///  Save/Update Calender for the selected marketId  
        /// </summary>
        /// <returns></returns>
        public void SavecalenderforMarket(Market marketObj)
        {
            using (new NHibernateSessionContext(SessionName))
            {
                using (var trans = new TransactionScope())
                {
                    Session.SaveOrUpdate(marketObj);
                    trans.Complete();  
                }
            }
        }

        public Market CheckCalenderExistsForMarket(Guid marketid) {

            using (new NHibernateSessionContext(SessionName))
            {
                using (var trans = new TransactionScope())
                {
                    var spec = new Specification<Market>(d => d.Id == marketid);
                    var marketobj = Find(spec);
                    marketobj.FirstOrDefault().Calendars.Any();
                    return marketobj.FirstOrDefault();
                }
            }
        }

    }


    

  
}
