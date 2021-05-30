using Delivery.Infrastructure.Repositories.MsSql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Application
{
    public class MsSqlDeliveryProvider : DeliveryProvider
    {
        public MsSqlDeliveryProvider()
        {
            addresses = new AddressMsSql();
            clients = new ClientMsSql();
            orders = new OrderMsSql();
            products = new ProductMsSql();
            history = new OrderHistoryMsSql();
        }
    }
}
