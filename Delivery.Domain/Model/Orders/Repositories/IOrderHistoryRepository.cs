using System;
using System.Collections.Generic;
using System.Text;

using Delivery.Domain.Model.Clients;

namespace Delivery.Domain.Model.Orders.Repositories
{
    public interface IOrderHistoryRepository
    {
        void AddAction(Client client, Order order, OrderAction action,
            DateTime time = default, string description = "");

        IEnumerable<OrderHistoryItem> GetActionsByOrder(Order order);
        IEnumerable<OrderHistoryItem> GetActionsByClient(Client client);
        IEnumerable<OrderHistoryItem> GetActionsByPeriodOfTime(DateTime since, DateTime to);
    }
}
