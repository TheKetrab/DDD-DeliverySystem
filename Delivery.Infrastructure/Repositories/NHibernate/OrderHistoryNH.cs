using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Orders;
using Delivery.Domain.Model.Orders.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Infrastructure.Repositories.NHibernate
{
    public class OrderHistoryNH : IOrderHistoryRepository
    {
        public void AddAction(Client client, Order order, OrderAction action, DateTime time = default, string description = "")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHistoryItem> GetActionsByClient(Client client)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHistoryItem> GetActionsByOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHistoryItem> GetActionsByPeriodOfTime(DateTime since, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
