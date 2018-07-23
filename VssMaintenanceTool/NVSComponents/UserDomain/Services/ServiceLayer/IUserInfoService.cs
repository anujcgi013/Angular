using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.Repositories;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Common;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;


namespace Volvo.VSSMaintenance.UserDomain.ServiceLayer
{
    public interface IUserInfoService
    {
        
        UserOrganisationDTO GetUserOrganisationInfo(UserOrganisationSearch searchCriteria);
        UserInfo GetUserDetail(string BaldoUserId);
        OrganisationInfo GetOrganisationDetail(Guid OrganisationId);
        RUSettingsInfo GetRUSettingsDetail(Guid RUSettingsId);
        UserProfileDTO GetUserProfileInfo(UserProfileSearch searchCriteria);
    }
}
