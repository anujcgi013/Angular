using System;
using System.Collections;
using System.Collections.Generic;
using Volvo.NVS.Persistence.NHibernate.Repositories;
using Volvo.NVS.Persistence.NHibernate.SessionHandling;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.RepositoryInterfaces;

namespace Volvo.VSSMaintenance.UserDomain.InfrastructureLayer.Repositories
{
    public class ChartDataRepository : GenericRepository<ChartData>, IChartDataRepository
    {
        public ChartDataRepository()
        {

        }
        public ChartDataRepository(string name) : base(name)
        {

        }
        public IList<ChartData> GetChartData()
        {
            using (new NHibernateSessionContext(SessionName))
            {
                var query = Session.CreateSQLQuery("exec GETCHARTDATA");
                var model = new List<ChartData>();
                foreach (var dataRows in query.List())
                {
                    if (((object[])dataRows) != null)
                    {
                        model.Add(new ChartData()
                        {
                            Created = Convert.ToDateTime(((object[])dataRows)[0]),
                            NumOfQuotes = Convert.ToInt32(((object[])dataRows)[1]),
                            NumOfOrders = Convert.ToInt32(((object[])dataRows)[2])
                        });
                    }
                }
                return model;
            }

        }


    }
}