using System;
using System.Collections.Generic;
using System.Text;

using Delivery.Domain.Model.Orders;
using Delivery.Domain.Model.Clients;

namespace Delivery.Application
{
    public interface IDeliveryService
    {
        bool VerifyPassword(string email, string password);
        IEnumerable<Order> GetOwnOrders(string email);
        void AddOrder(Order order);
        Client GetClientByEmail(string email);

    }
}
