using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.Repositories;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Common;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer.RepositoryInterfaces
{
    public interface IUserInfoRepository : IGenericRepository<UserInfo, string>
    {
        UserOrganisationDTO GetUserOrganisationInfo(UserOrganisationSearch userSearch);
        UserInfo GetUserDetail(string BaldoUserId);
        OrganisationInfo GetOrganisationDetail(Guid OrganisationId);
        RUSettingsInfo GetRUSettingsDetail(Guid OrganisationId);
        UserProfileDTO GetUserProfileInfo(UserProfileSearch searchCriteria);
    }
}
