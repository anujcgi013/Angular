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
    public class MarketMap : ClassMapping<Market>
    {
        public MarketMap()
        {
            Table("[Market]");
            Schema("[dbo]");
            Lazy(false);

            Id(x => x.Id, x => x.Generator(Generators.Guid));
            Property(x => x.MarketId);
            Property(x => x.Description);

            Bag(x => x.Calendars, m =>
            {
                m.Key(k => k.Column("MarketId"));
                m.Inverse(true);
                //m.Lazy(CollectionLazy.NoLazy);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
            }, map => map.OneToMany(x => x.Class(typeof(Calendar))));

        }


    }
}
