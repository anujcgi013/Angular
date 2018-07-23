using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.NHibernate.Repositories;
using Volvo.VSS.LogDomain.DomainLayer.Entities;
using Volvo.VSS.LogDomain.DomainLayer.RepositoryInterfaces;

namespace Volvo.VSS.LogDomain.InfrastructureLayer.Repositories
{
    public class ProcessLogRepository : GenericRepository<ProcessLog, string>, IProcessLogRepository
    {
        public IList<ProcessLog> GetProcessLogDeatils()
        {
            return Session.QueryOver<ProcessLog>().List<ProcessLog>().ToList();
        }
    }
}
