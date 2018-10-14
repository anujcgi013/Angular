using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Core.Unity;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.RepositoryInterfaces;
using Volvo.VSSMaintenance.UserDomain.ServiceLayer;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer
{
    public partial class UserService : IUserService
    {
        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        public UserService()
        {
            UserRepository = Container.Resolve<IUserRepository>();
        }
        public virtual User GetUser(string baldoUserId) => UserRepository.GetUser(baldoUserId);
        protected IUserRepository UserRepository { get; }
    }
}
