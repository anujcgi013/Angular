using System;
using System.Collections.Generic;
using Volvo.NVS.Core.Unity;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.RepositoryInterfaces;
using Volvo.VSSMaintenance.UserDomain.InfrastructureLayer.Repositories;
using Volvo.VSSMaintenance.UserDomain.ServiceLayer;


namespace Volvo.VSSMaintenance.UserDomain.DomainLayer
{

    public class ChartDataService : IChartDataService
    {
        protected IChartDataRepository ChartDataRepository { get; set; }
        public ChartDataService()
        {

            ChartDataRepository = Container.Resolve<IChartDataRepository>();
        }

        public ChartDataService(IChartDataRepository chartData)
        {

            ChartDataRepository = chartData;
        }

        public IList<ChartData> GetChartData()
        {
            return ChartDataRepository.GetChartData();
        }
    }
}
