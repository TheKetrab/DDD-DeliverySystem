using Delivery.Infrastructure.Repositories.InMemory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Application
{
    public class IMDeliveryProviderEmpty : DeliveryProvider
    {
        public IMDeliveryProviderEmpty()
        {
            addresses = new AddressIM();
            clients = new ClientIM(addresses);
            orders = new OrderIM(addresses, clients);
            products = new ProductIM();
            history = new OrderHistoryIM();
        }
    }
}
