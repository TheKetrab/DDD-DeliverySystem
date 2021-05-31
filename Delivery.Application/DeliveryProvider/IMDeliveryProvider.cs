using Delivery.Infrastructure.Repositories.InMemory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Application
{
    public class IMDeliveryProvider : IMDeliveryProviderEmpty
    {
        public IMDeliveryProvider()
        {
            addresses = new AddressIM(10);
            clients = new ClientIM(addresses, 10);
            orders = new OrderIM(addresses, clients, 1000);
            products = new ProductIM(100);
            history = new OrderHistoryIM();
        }
    }
}
