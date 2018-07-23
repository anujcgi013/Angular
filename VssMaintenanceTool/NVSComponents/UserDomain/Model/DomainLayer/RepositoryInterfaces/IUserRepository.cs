using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.Repositories;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer.RepositoryInterfaces
{
    public interface IUserRepository:IGenericRepository<User,String>
    {
         User GetUser(String baldoUserId);
    }
}
