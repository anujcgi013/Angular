using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.VSSMaintenance.UserDomain.DomainLayer.Entities;

namespace Volvo.VSSMaintenance.UserDomain.InfrastructureLayer.Mappings
{

    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Table("[User]");
            Schema("[dbo]");
            Lazy(true);
            Id(
                x => x.Id,
                m => m.Generator(Generators.Assigned)
            );
            Property(x => x.FirstName);
            Property(x => x.BaldoUserId);
            //Property(
            //    x => x.FirstName,
            //    m =>
            //    {
            //        m.NotNullable(true);
            //        m.Unique(false);
            //    });

        }
    }
}

