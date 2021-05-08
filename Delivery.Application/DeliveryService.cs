using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Delivery.Infrastructure.Repositories;
using Delivery.Domain.Model.Addresses.Repositories;
using Delivery.Domain.Model.Clients.Repositories;
using Delivery.Domain.Model.Orders.Repositories;
using Delivery.Domain.Model.Products.Repositories;

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
            addresses = new AddressIM();
            clients = new ClientIM(addresses);
            orders = new OrderIM(addresses, clients);
            products = new ProductIM();
            history = new OrderHistoryIM();
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
            var c = clients.GetClientByEmail(email);
            // string hash = "abc";
            // TODO: compute hash
            // if (c.Hash == hash) return true;

            if (password == "aaa")
                return true;

            return false;
        }
    }
}
