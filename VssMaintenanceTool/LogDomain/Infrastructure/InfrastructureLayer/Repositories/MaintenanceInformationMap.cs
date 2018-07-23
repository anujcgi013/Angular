using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.VSS.LogDomain.DomainLayer.Entities;


namespace Volvo.VSS.LogDomain.InfrastructureLayer.Repositories
{
    public class MaintenanceInformationMap : ClassMapping<MaintenanceInformation>
    {
        //changes for log domain
        public MaintenanceInformationMap()
        {
            Table("[MaintenanceInformation]");
            Schema("[dbo]");
            Lazy(true);
            Id(x => x.Id, x => x.Generator(Generators.Identity));
            Property(x => x.Header);
            Property(x => x.Message);
            Property(x => x.ValidFrom);
            Property(x => x.ValidTo);
            Property(x => x.Created);
            Property(x => x.CreatedBy);


        }
    }
}
