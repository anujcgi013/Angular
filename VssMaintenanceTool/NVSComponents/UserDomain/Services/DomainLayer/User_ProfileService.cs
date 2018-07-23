using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.RepositoryInterfaces;
using Volvo.VSSMaintenance.UserDomain.ServiceLayer;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer
{
    public partial class User_ProfileService : IUser_ProfileService
    {
        public User_ProfileService(IUser_ProfileRepository user_ProfileRepository)
        {
            User_ProfileRepository = user_ProfileRepository;
        }

        public virtual IQueryable<User_Profile> GetUserProfile(string UserId) => User_ProfileRepository.GetUserProfiles(UserId);
        public virtual bool IsUserAdmin(string UserId) => User_ProfileRepository.IsUserAdmin(UserId);
        protected IUser_ProfileRepository User_ProfileRepository { get; }
    }
}
