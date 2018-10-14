using Common;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Transform;
using Volvo.NVS.Persistence.NHibernate.Repositories;
using Volvo.NVS.Persistence.NHibernate.SessionHandling;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Common;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.RepositoryInterfaces;

namespace Volvo.VSSMaintenance.UserDomain.InfrastructureLayer.Repositories
{
    public class GDPRRepository : GenericRepository<GDPRInfo, String>, IGDPRRepository
    {

        public GDPRRepository()
        {

        }
        public GDPRRepository(string name) : base(name)
        {

        }

        public GDPRDTO GetGDPRInfoDetail(GDPRInfoSearch searchCriteria)
        {
            var Skip = searchCriteria.Skip;
            var Take = searchCriteria.Take;
            GDPRDTO GDPRInfoDTO = new GDPRDTO();
            using (new NHibernateSessionContext(SessionName))
            {

                var query = Session.CreateSQLQuery("exec GetGDPRInfo @SearchString=:SearchString")
                    .SetParameter("SearchString", searchCriteria.SearchString);
                var list = new List<GDPRInfo>();
                foreach (var item in query.List())
                {
                    list.Add(new GDPRInfo()
                    {
                        PersonType = (((object[])item)[0] == null) ? string.Empty : ((object[])item)[0].ToString(),
                        UserID = (((object[])item)[1] == null) ? string.Empty : ((object[])item)[1].ToString(),
                        Salutation = (((object[])item)[2] == null) ? string.Empty : ((object[])item)[2].ToString(),
                        Title = (((object[])item)[3] == null) ? string.Empty : ((object[])item)[3].ToString(),
                        FirstName = (((object[])item)[4] == null) ? string.Empty : ((object[])item)[4].ToString(),
                        MiddleName = (((object[])item)[5] == null) ? string.Empty : ((object[])item)[5].ToString(),
                        SurName = (((object[])item)[6] == null) ? string.Empty : ((object[])item)[6].ToString(),
                        Gender = (((object[])item)[7] == null) ? string.Empty : ((object[])item)[7].ToString(),
                        Profession = (((object[])item)[8] == null) ? string.Empty : ((object[])item)[8].ToString(),
                        Email = (((object[])item)[9] == null) ? string.Empty : ((object[])item)[9].ToString(),
                        Phone = (((object[])item)[10] == null) ? string.Empty : ((object[])item)[10].ToString(),
                        Mobile = (((object[])item)[11] == null) ? string.Empty : ((object[])item)[11].ToString(),
                        Note = (((object[])item)[12] == null) ? string.Empty : ((object[])item)[12].ToString(),
                        Fax = (((object[])item)[13] == null) ? string.Empty : ((object[])item)[13].ToString(),
                        Signature = Encoding.ASCII.GetBytes((((object[])item)[14] == null) ? string.Empty : ((object[])item)[14].ToString())
                    });
                }

                GDPRInfoDTO.GDPRInfoList = list;
            }
            return GDPRInfoDTO;
        }

        public List<GDPRInfo> GetGDPRInfo(GDPRInfoSearch searchCriteria)
        {
            List<GDPRInfo> result = new List<GDPRInfo>();
            using (new NHibernateSessionContext(SessionName))
            {
                var query = Session.CreateSQLQuery("exec GetGDPRInfo @SearchString=:SearchString")
                     .SetParameter("SearchString", searchCriteria.SearchString);
                var list = new List<GDPRInfo>();
                foreach (var item in query.List())
                {
                    list.Add(new GDPRInfo()
                    {
                        PersonType = (((object[])item)[0] == null) ? string.Empty : ((object[])item)[0].ToString(),
                        UserID = (((object[])item)[1] == null) ? string.Empty : ((object[])item)[1].ToString(),
                        Salutation = (((object[])item)[2] == null) ? string.Empty : ((object[])item)[2].ToString(),
                        Title = (((object[])item)[3] == null) ? string.Empty : ((object[])item)[3].ToString(),
                        FirstName = (((object[])item)[4] == null) ? string.Empty : ((object[])item)[4].ToString(),
                        MiddleName = (((object[])item)[5] == null) ? string.Empty : ((object[])item)[5].ToString(),
                        SurName = (((object[])item)[6] == null) ? string.Empty : ((object[])item)[6].ToString(),
                        Gender = (((object[])item)[7] == null) ? string.Empty : ((object[])item)[7].ToString(),
                        Profession = (((object[])item)[8] == null) ? string.Empty : ((object[])item)[8].ToString(),
                        Email = (((object[])item)[9] == null) ? string.Empty : ((object[])item)[9].ToString(),
                        Phone = (((object[])item)[10] == null) ? string.Empty : ((object[])item)[10].ToString(),
                        Mobile = (((object[])item)[11] == null) ? string.Empty : ((object[])item)[11].ToString(),
                        Note = (((object[])item)[12] == null) ? string.Empty : ((object[])item)[12].ToString(),
                        Fax = (((object[])item)[13] == null) ? string.Empty : ((object[])item)[13].ToString(),
                        Signature = (((object[])item)[14] == null) ? null : ObjectToByteArray(((object[])item)[14])
                    });
                }
                result = list;
            }
            return result;
        }

        public byte[] ObjectToByteArray(Object obj)
        {
            byte[] Signature = (byte[])obj;
            return Signature;
        }
    }
}
