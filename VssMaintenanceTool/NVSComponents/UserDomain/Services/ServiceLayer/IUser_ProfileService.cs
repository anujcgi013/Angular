using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;

namespace Volvo.VSSMaintenance.UserDomain.ServiceLayer
{
    public interface IUser_ProfileService
    {
        IQueryable<User_Profile> GetUserProfile(string UserId);
        bool IsUserAdmin(string UserId);
    }
}
