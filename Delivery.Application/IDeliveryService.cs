using System;
using System.Collections.Generic;
using System.Text;

using Delivery.Domain.Model.Orders;
using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Addresses;
using Delivery.Domain.Model.Products;

namespace Delivery.Application
{
    public interface IDeliveryService
    {
        #region Clients
        Client GetClientByEmail(string email);
        void CreateNewClient(Client c);
        bool VerifyPassword(Client c, string password);
        #endregion


        #region Orders
        IEnumerable<Order> GetClientOrders(Client c);
        void CreateNewOrder(Order o);
        void CancelOrder(Order o);
        IEnumerable<OrderHistoryItem> GetOrderHistory(Order o);
        #endregion

        #region Addresses
        void CreateNewAddress(Address a);
        IEnumerable<Address> GetAllAddresses();
        #endregion

        #region Products
        void CreateNewProduct(Product p);
        IEnumerable<Product> GetAllProducts();
        #endregion

    }
}
