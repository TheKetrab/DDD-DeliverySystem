using Delivery.Domain.Model.Addresses.Repositories;
using Delivery.Domain.Model.Clients.Repositories;
using Delivery.Domain.Model.Orders.Repositories;
using Delivery.Domain.Model.Products.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Application
{
    public abstract class DeliveryProvider
    {
        public IAddressRepository addresses;
        public IClientRepository clients;
        public IOrderRepository orders;
        public IProductRepository products;
        public IOrderHistoryRepository history;
    }
}
