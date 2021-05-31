using System;
using System.Collections.Generic;
using System.Text;
using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Addresses;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Delivery.Infrastructure.Repositories.NHibernate.Mappings
{
    public class ClientMapping : ClassMapping<Client>
    {
        public ClientMapping()
        {
            Table("[Clients]");
            Id(e => e.Id, m => m.Generator(Generators.Identity));
            Property(e => e.Name);
            Property(e => e.Email);
            Property(e => e.Hash);
            Property(e => e.Phone);

            Property(e => e.Role, m => m.Type<RoleType>());

            ManyToOne<Address>(e => e.Address, m =>
            {
                m.Column("AddressId");
                m.Fetch(FetchKind.Join);
                m.ForeignKey("none");
                m.Lazy(LazyRelation.NoLazy);
            });

        }
    }
}
