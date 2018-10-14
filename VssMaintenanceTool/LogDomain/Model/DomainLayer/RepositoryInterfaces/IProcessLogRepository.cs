using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.NVS.Persistence.Repositories;
using Volvo.VSS.LogDomain.DomainLayer.Entities;

namespace Volvo.VSS.LogDomain.DomainLayer.RepositoryInterfaces
{
    public interface IProcessLogRepository : IGenericRepository<ProcessLog, string>
    {
        IList<ProcessLog> GetProcessLogDeatils();
    }
}
