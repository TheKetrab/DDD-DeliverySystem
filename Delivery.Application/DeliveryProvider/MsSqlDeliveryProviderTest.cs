using Delivery.Infrastructure.Repositories.MsSql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Application
{
    public class MsSqlDeliveryProviderTest : DeliveryProvider
    {
        public MsSqlDeliveryProviderTest()
        {
            addresses = new AddressMsSql("AddressTest","NationsTest");
            clients = new ClientMsSql("ClientsTest");
            orders = new OrderMsSql("OrdersTest","OrderStatusTest");
            products = new ProductMsSql("ProductsTest");
            history = new OrderHistoryMsSql("OrdersTest","OrderActionTest");
        }
    }
}
