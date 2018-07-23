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
    public class User_ProfileRepository : GenericRepository<User_Profile, string>, IUser_ProfileRepository
    {
        public User_ProfileRepository()
        {
        }
        public User_ProfileRepository(string name) : base(name)
        {
        }
        public IQueryable<User_Profile> GetUserProfiles(String userId)
        {
            using (new NHibernateSessionContext(SessionName))
            {
                return Session.QueryOver<User_Profile>().List<User_Profile>().Where(m => m.UserId == userId).ToList().AsQueryable();
            }
        }

        public bool IsUserAdmin(String userId)
        {
            using (new NHibernateSessionContext(SessionName))
            {
                return Session.QueryOver<User_Profile>().List<User_Profile>().Any(m => m.UserId == userId && m.ProfileId == "0");
            }
        } 
    }
}
