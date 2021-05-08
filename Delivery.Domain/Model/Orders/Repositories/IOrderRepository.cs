using System;
using System.Collections.Generic;
using System.Text;

using Delivery.Generic.Interfaces;
using Delivery.Domain.Model.Clients;

namespace Delivery.Domain.Model.Orders.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetClientOrders(Client c);
    }
}
