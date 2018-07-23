using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Common;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.RepositoryInterfaces;
using Volvo.VSSMaintenance.UserDomain.InfrastructureLayer.Repositories;
using Volvo.VSSMaintenance.UserDomain.ServiceLayer;
using Volvo.NVS.Core.Unity;

namespace Volvo.VSSMaintenance.UserDomain.DomainLayer
{
    public class GDPRService : IGDPRService
    {
        protected IGDPRRepository GDPRRepository { get; }
        public GDPRService(IGDPRRepository gdprRepository)
        {
            GDPRRepository = gdprRepository;
        }
        public GDPRService()
        {
            GDPRRepository = Container.Resolve<IGDPRRepository>();
        }

        public GDPRDTO GetGDPRInfoDetail(GDPRInfoSearch searchCriteria)
        {
            return GDPRRepository.GetGDPRInfoDetail(searchCriteria);
        }

        public List<GDPRInfo> GetGDPRInfo(GDPRInfoSearch searchCriteria)
        {
            return GDPRRepository.GetGDPRInfo(searchCriteria);
        }
    }
}
