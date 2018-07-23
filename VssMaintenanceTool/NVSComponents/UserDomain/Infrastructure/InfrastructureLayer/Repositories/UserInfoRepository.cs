using Common;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Repositories;
using Volvo.NVS.Persistence.NHibernate.SessionHandling;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Common;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.RepositoryInterfaces;

namespace Volvo.VSSMaintenance.UserDomain.InfrastructureLayer.Repositories
{
    public class UserInfoRepository : GenericRepository<UserInfo, String>, IUserInfoRepository
    {
        public UserInfoRepository()
        {

        }
        public UserInfoRepository(string name) : base(name)
        {

        }
        public IList<UserInfo> GetUserInfo(UserSearch userSearch)
        {
            using (new NHibernateSessionContext(SessionName))
            {
                return null;
            }
        }
        public UserOrganisationDTO GetUserOrganisationInfo(UserOrganisationSearch searchCriteria)
        {
            var Skip = searchCriteria.Skip;
            var Take = searchCriteria.Take;
            UserOrganisationDTO userOrganisationDTO = new UserOrganisationDTO();
            using (new NHibernateSessionContext(SessionName))
            {
                ICriteria query = this.Session.CreateCriteria(typeof(UserOrganisationInfo)).AddOrder(Order.Asc("FirstName"));
                if (!String.IsNullOrWhiteSpace(searchCriteria.BaldoUserId))
                {
                    query.Add(Restrictions.Like("BaldoUserId", "%" + searchCriteria.BaldoUserId + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.FirstName))
                {
                    query.Add(Restrictions.Like("FirstName", "%" + searchCriteria.FirstName + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.SurName))
                {
                    query.Add(Restrictions.Like("SurName", "%" + searchCriteria.SurName + "%"));
                }
                if (searchCriteria.UserId.HasValue)
                {
                    query.Add(Restrictions.Eq("UserId", searchCriteria.UserId));
                }
                if (searchCriteria.OrganisationId.HasValue)
                {
                    query.Add(Restrictions.Eq("OrganisationId", searchCriteria.OrganisationId));
                }
                if (searchCriteria.RUSettingsId.HasValue)
                {
                    query.Add(Restrictions.Eq("RUSettingsId", searchCriteria.RUSettingsId));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.CDBPartyId))
                {
                    query.Add(Restrictions.Like("CDBPartyId", "%" + searchCriteria.CDBPartyId + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.CommonName))
                {
                    query.Add(Restrictions.Like("CommonName", "%" + searchCriteria.CommonName + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.LegalName))
                {
                    query.Add(Restrictions.Like("LegalName", "%" + searchCriteria.LegalName + "%"));
                }

                userOrganisationDTO.UserOrganisationInfoList = query.SetFirstResult(Skip).SetMaxResults(Take).Future<UserOrganisationInfo>().ToList();
            }
            using (new NHibernateSessionContext(SessionName))
            {
                ICriteria query = this.Session.CreateCriteria(typeof(UserOrganisationInfo));
                if (!String.IsNullOrWhiteSpace(searchCriteria.BaldoUserId))
                {
                    query.Add(Restrictions.Like("BaldoUserId", "%" + searchCriteria.BaldoUserId + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.FirstName))
                {
                    query.Add(Restrictions.Like("FirstName", "%" + searchCriteria.FirstName + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.SurName))
                {
                    query.Add(Restrictions.Like("SurName", "%" + searchCriteria.SurName + "%"));
                }
                if (searchCriteria.UserId.HasValue)
                {
                    query.Add(Restrictions.Eq("UserId", searchCriteria.UserId));
                }
                if (searchCriteria.OrganisationId.HasValue)
                {
                    query.Add(Restrictions.Eq("OrganisationId", searchCriteria.OrganisationId));
                }
                if (searchCriteria.RUSettingsId.HasValue)
                {
                    query.Add(Restrictions.Eq("RUSettingsId", searchCriteria.RUSettingsId));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.CDBPartyId))
                {
                    query.Add(Restrictions.Like("CDBPartyId", "%" + searchCriteria.CDBPartyId + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.CommonName))
                {
                    query.Add(Restrictions.Like("CommonName", "%" + searchCriteria.CommonName + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.LegalName))
                {
                    query.Add(Restrictions.Like("LegalName", "%" + searchCriteria.LegalName + "%"));
                }
                userOrganisationDTO.Total = query.SetProjection(Projections.Count(Projections.Id())).FutureValue<int>().Value;

            }
            return userOrganisationDTO;
        }
        public UserInfo GetUserDetail(string BaldoUserId)
        {
            UserInfo result = new UserInfo();
            using (new NHibernateSessionContext(SessionName))
            {
                result = Session.QueryOver<UserInfo>().Where(m => m.BaldoUserId == BaldoUserId).SingleOrDefault();
            }
            return result;
        }
        public OrganisationInfo GetOrganisationDetail(Guid OrganisationId)
        {
            OrganisationInfo result = new OrganisationInfo();
            using (new NHibernateSessionContext(SessionName))
            {
                result = Session.QueryOver<OrganisationInfo>().Where(m => m.OrganisationId == OrganisationId).SingleOrDefault();
            }
            return result;
        }

        public RUSettingsInfo GetRUSettingsDetail(Guid RUSettingsId)
        {
            RUSettingsInfo result = new RUSettingsInfo();
            using (new NHibernateSessionContext(SessionName))
            {
                result = Session.QueryOver<RUSettingsInfo>().Where(m => m.RUSettingsId == RUSettingsId).SingleOrDefault();
            }
            return result;
        }

        public UserProfileDTO GetUserProfileInfo(UserProfileSearch searchCriteria)
        {
            var Skip = searchCriteria.Skip;
            var Take = searchCriteria.Take;
            UserProfileDTO userProfileDTO = new UserProfileDTO();
            using (new NHibernateSessionContext(SessionName))
            {
                ICriteria query = this.Session.CreateCriteria(typeof(UserProfileInfo)).AddOrder(Order.Asc("FirstName"));
                if (searchCriteria.UserProfileId.HasValue)
                {
                    query.Add(Restrictions.Eq("UserProfileId", searchCriteria.UserProfileId));
                }
                if (searchCriteria.ProfileId.HasValue)
                {
                    query.Add(Restrictions.Eq("ProfileId", searchCriteria.ProfileId));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.Profile))
                {
                    query.Add(Restrictions.Like("Profile", "%" + searchCriteria.Profile + "%"));
                }
                if (searchCriteria.UserId.HasValue)
                {
                    query.Add(Restrictions.Eq("UserId", searchCriteria.UserId));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.BaldoUserId))
                {
                    query.Add(Restrictions.Like("BaldoUserId", "%" + searchCriteria.BaldoUserId + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.FirstName))
                {
                    query.Add(Restrictions.Like("FirstName", "%" + searchCriteria.FirstName + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.SurName))
                {
                    query.Add(Restrictions.Like("SurName", "%" + searchCriteria.SurName + "%"));
                }
                userProfileDTO.UserProfileInfoList = query.SetFirstResult(Skip).SetMaxResults(Take).Future<UserProfileInfo>().ToList();
            }
            using (new NHibernateSessionContext(SessionName))
            {
                ICriteria query = this.Session.CreateCriteria(typeof(UserProfileInfo));
                if (searchCriteria.UserProfileId.HasValue)
                {
                    query.Add(Restrictions.Eq("UserProfileId", searchCriteria.UserProfileId));
                }
                if (searchCriteria.ProfileId.HasValue)
                {
                    query.Add(Restrictions.Eq("ProfileId", searchCriteria.ProfileId));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.Profile))
                {
                    query.Add(Restrictions.Like("Profile", "%" + searchCriteria.Profile + "%"));
                }
                if (searchCriteria.UserId.HasValue)
                {
                    query.Add(Restrictions.Eq("UserId", searchCriteria.UserId));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.BaldoUserId))
                {
                    query.Add(Restrictions.Like("BaldoUserId", "%" + searchCriteria.BaldoUserId + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.FirstName))
                {
                    query.Add(Restrictions.Like("FirstName", "%" + searchCriteria.FirstName + "%"));
                }
                if (!String.IsNullOrWhiteSpace(searchCriteria.SurName))
                {
                    query.Add(Restrictions.Like("SurName", "%" + searchCriteria.SurName + "%"));
                }
                userProfileDTO.Total = query.SetProjection(Projections.Count(Projections.Id())).FutureValue<int>().Value;
            }
            return userProfileDTO;
        }
    }
}
