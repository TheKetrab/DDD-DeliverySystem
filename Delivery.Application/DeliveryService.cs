using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Delivery.Infrastructure.Repositories.InMemory;
using Delivery.Infrastructure.Repositories.MsSql;
using Delivery.Domain.Model.Addresses.Repositories;
using Delivery.Domain.Model.Clients.Repositories;
using Delivery.Domain.Model.Orders.Repositories;
using Delivery.Domain.Model.Products.Repositories;
using Delivery.Generic.Security;

namespace Delivery.Application
{
    public class DeliveryService : IDeliveryService
    {
        // objects in memory
        IAddressRepository addresses;
        IClientRepository clients;
        IOrderRepository orders;
        IProductRepository products;
        IOrderHistoryRepository history;

        public DeliveryService()
        {
            //addresses = new AddressIM();
            //clients = new ClientIM(addresses);
            //orders = new OrderIM(addresses, clients);
            //products = new ProductIM();
            //history = new OrderHistoryIM();

            addresses = new AddressMsSql();
            clients = new ClientMsSql();
            orders = new OrderMsSql();
            products = new ProductMsSql();
            history = new OrderHistoryMsSql();
        }


        public void AddOrder(Order order)
        {
            orders.Insert(order);
        }

        public Client GetClientByEmail(string email)
        {
            return clients.GetClientByEmail(email);
        }

        public IEnumerable<Order> GetOwnOrders(string email)
        {
            var client = clients.GetClientByEmail(email);
            return orders.GetClientOrders(client);
        }

        public bool VerifyPassword(string email, string password)
        {
            var client = clients.GetClientByEmail(email);
            var hash = Encryption.ComputeHexStringHash(password);

            return client.Hash == hash;
        }
    }
}
