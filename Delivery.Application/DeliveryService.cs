using System.Collections.Generic;

using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Orders;

using Delivery.Domain.Model.Addresses.Repositories;
using Delivery.Domain.Model.Clients.Repositories;
using Delivery.Domain.Model.Orders.Repositories;
using Delivery.Domain.Model.Products.Repositories;

using Delivery.Infrastructure.Repositories.InMemory;
using Delivery.Infrastructure.Repositories.MsSql;

using Delivery.Generic.Security;
using Delivery.Domain.Model.Addresses;
using Delivery.Domain.Model.Products;
using System;

namespace Delivery.Application
{
    public class DeliveryService : IDeliveryService
    {
        // repositories
        IAddressRepository addresses;
        IClientRepository clients;
        IOrderRepository orders;
        IProductRepository products;
        IOrderHistoryRepository history;

        public DeliveryService(DeliveryProvider provider)
        {
            addresses = provider.addresses;
            clients = provider.clients;
            orders = provider.orders;
            products = provider.products;
            history = provider.history;
        }

        public DeliveryService() : this(/*new IMDeliveryProvider()*/ new NHibernateDeliveryProvider()) { }

        #region Clients
        public void CreateNewClient(Client c)
        {
            clients.Insert(c);
        }

        public Client GetClientByEmail(string email)
        {
            return clients.GetClientByEmail(email);
        }

        public bool VerifyPassword(Client c, string password)
        {
            var hash = Encryption.ComputeHexStringHash(password);
            return c.Hash == hash;
        }
        #endregion
        #region Orders
        public void CreateNewOrder(Order o)
        {
            orders.Insert(o);
            history.AddAction(null, o, OrderAction.Create, DateTime.Now);
        }

        public void CancelOrder(Order o)
        {
            o.Status = Status.Canceled;
            history.AddAction(null, o, OrderAction.Cancel, DateTime.Now);
        }

        public IEnumerable<Order> GetClientOrders(Client c)
        {
            return orders.GetOrdersByClient(c);
        }

        public IEnumerable<OrderHistoryItem> GetOrderHistory(Order o)
        {
            return history.GetActionsByOrder(o);
        }

        #endregion
        #region Addresses
        public void CreateNewAddress(Address a)
        {
            addresses.Insert(a);
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            return addresses.FindAll();
        }
        #endregion
        #region Products
        public void CreateNewProduct(Product p)
        {
            products.Insert(p);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return products.FindAll();
        }
        #endregion
    }
}
