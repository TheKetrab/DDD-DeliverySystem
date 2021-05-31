using Delivery.Application;
using Delivery.Domain.Model.Addresses.Repositories;
using Delivery.Domain.Model.Clients.Repositories;
using Delivery.Domain.Model.Orders.Repositories;
using Delivery.Domain.Model.Products.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.ObjectMothers
{
    public static class RepositoryObjectMother
    {
        // ---------------     NOTE     ------------- 
        // every collection has at least 10 objects
        // -----------------------------------------
        const int min_cnt = 10;
        const string msg = "Minimum in test collection: 10";

        // install provider that is used while testing
        private static DeliveryProvider _provider = new NHibernateDeliveryProviderTest();

        public static IAddressRepository CreateAddressRepository()
        {
            if (_provider.addresses.Count < min_cnt)
                throw new Exception(msg);

            return _provider.addresses;
        }
        public static IClientRepository CreateClientRepository()
        {
            if (_provider.clients.Count < min_cnt)
                throw new Exception(msg);

            return _provider.clients;
        }
        public static IOrderRepository CreateOoderRepository()
        {
            if (_provider.orders.Count < min_cnt)
                throw new Exception(msg);

            return _provider.orders;
        }

        public static IProductRepository CreateProductRepository()
        {
            if (_provider.products.Count < min_cnt)
                throw new Exception(msg);

            return _provider.products;
        }

    }
}
