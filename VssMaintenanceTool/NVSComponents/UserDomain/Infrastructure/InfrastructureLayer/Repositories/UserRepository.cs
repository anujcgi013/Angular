using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Repositories;
using Volvo.NVS.Persistence.NHibernate.SessionHandling;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.RepositoryInterfaces;

namespace Volvo.VSSMaintenance.UserDomain.InfrastructureLayer.Repositories
{
    public class UserRepository : GenericRepository<User,String>, IUserRepository
    {
        public UserRepository()
        {
        }
        public UserRepository(string name) : base(name)
        {
        }
        public User GetUser(String baldoUserId)
        {
            using (new NHibernateSessionContext(SessionName))
            {
                return Session.QueryOver<User>().List<User>().Where(m => m.BaldoUserId.ToUpper() == baldoUserId.ToUpper()).ToList().FirstOrDefault();
            }
        }
        public User GetUserInfo(String baldoUserId)
        {
            using (new NHibernateSessionContext(SessionName))
            {
                return Session.QueryOver<User>().List<User>().Where(m => m.BaldoUserId.ToUpper() == baldoUserId.ToUpper()).ToList().FirstOrDefault();
            }
        }
    }
}
