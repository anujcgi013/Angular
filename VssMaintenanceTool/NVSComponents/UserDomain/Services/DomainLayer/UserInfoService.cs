using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Core.Unity;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Common;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.RepositoryInterfaces;
using Volvo.VSSMaintenance.UserDomain.InfrastructureLayer.Repositories;
using Volvo.VSSMaintenance.UserDomain.ServiceLayer;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer
{
    public class UserInfoService: IUserInfoService
    {
        protected IUserInfoRepository UserInfoRepository { get; }
        public UserInfoService(IUserInfoRepository userInfoRepository)
        {
            UserInfoRepository = userInfoRepository;
        }
        public UserInfoService()
        {
            UserInfoRepository = Container.Resolve<IUserInfoRepository>();
        }
        public UserInfo GetUserDetail(string BaldoUserId)
        {
           return UserInfoRepository.GetUserDetail(BaldoUserId);
        }
       
        public UserOrganisationDTO GetUserOrganisationInfo(UserOrganisationSearch searchCriteria)
        {
            return UserInfoRepository.GetUserOrganisationInfo(searchCriteria);
        }

        public OrganisationInfo GetOrganisationDetail(Guid OrganisationId)
        {
            return UserInfoRepository.GetOrganisationDetail(OrganisationId);
        }
        public RUSettingsInfo GetRUSettingsDetail(Guid RUSettingsId)
        {
            return UserInfoRepository.GetRUSettingsDetail(RUSettingsId);
        }
        public UserProfileDTO GetUserProfileInfo(UserProfileSearch searchCriteria)
        {
            return UserInfoRepository.GetUserProfileInfo(searchCriteria);
        }

    }
}
