using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Core.Unity.Configuration;
using Volvo.VSSMaintenance.UserDomain.DomainLayer;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.RepositoryInterfaces;
using Volvo.VSSMaintenance.UserDomain.InfrastructureLayer.Repositories;
using Volvo.VSSMaintenance.UserDomain.ServiceLayer;

namespace Volvo.VSSMaintenance.UserDomain.Configuration
{
    public class UserDomainConfigurator : IContainerConfigurator
    {
        public void Configure(IUnityContainer container) => container
                    .RegisterType<IUserInfoService, UserInfoService>()
                    .RegisterType<IUserInfoRepository, UserInfoRepository>()
                    .RegisterType<IUserService, UserService>()
                    .RegisterType<IUserRepository, UserRepository>()
                    .RegisterType<IUser_ProfileService, User_ProfileService>()
                    .RegisterType<IUser_ProfileRepository, User_ProfileRepository>()
                    .RegisterType<IMarketService, MarketService>()
                    .RegisterType<IMarketRepository, MarketRepository>()
                    .RegisterType<IGDPRService, GDPRService>()
                    .RegisterType<IGDPRRepository, GDPRRepository>()
                    .RegisterType<IChartDataService, ChartDataService>()
                    .RegisterType<IChartDataRepository, ChartDataRepository>();

    }
}
