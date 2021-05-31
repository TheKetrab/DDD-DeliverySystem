using System;
using System.Collections.Generic;
using System.Text;

using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Delivery.Domain.Model.Orders;
using Delivery.Domain.Model.Addresses;

namespace Delivery.Infrastructure.Repositories.NHibernate.Mappings
{
    public class OrderMapping : ClassMapping<Order>
    {
        public OrderMapping()
        {
            Table("[Orders]");
            Id(e => e.Id, m => m.Generator(Generators.Identity));

            ManyToOne(e => e.DeliveryAddress, m =>
            {
                m.Column("DeliveryAddressId");
                m.Fetch(FetchKind.Join);
                m.ForeignKey("none");
                m.Lazy(LazyRelation.NoLazy);
            });

            ManyToOne(e => e.Owner, m =>
            {
                m.Column("OwnerId");
                m.Fetch(FetchKind.Join);
                m.ForeignKey("none");
                m.Lazy(LazyRelation.NoLazy);
            });

            Property(e => e.Status, m => m.Type<OrderStatusType>());

            Property(e => e.LatestDeliveryDate, m =>
            {
                m.Column("LatestDate");
            });

        }
    }
}