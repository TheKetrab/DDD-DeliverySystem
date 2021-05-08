using System;
using System.Collections.Generic;
using System.Text;
using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Orders;
using Delivery.Domain.Model.Orders.Repositories;

using System.Linq;

namespace Delivery.Infrastructure.Repositories
{
    public class OrderHistoryIM : IOrderHistoryRepository
    {
        List<OrderHistoryItem> history;

        public OrderHistoryIM()
        {
            history = new List<OrderHistoryItem>();
        }

        public void AddAction(Client client, Order order, OrderAction action,
            DateTime time = default, string description = "")
        {
            history.Add(new OrderHistoryItem()
            {
                Action = action,
                Client = client,
                Description = description,
                Order = order,
                Time = time
            });
        }

        public IEnumerable<OrderHistoryItem> GetActionsByClient(Client client)
        {
            var res = from item in history
                      where item.Client == client
                      select item;

            return res;
        }

        public IEnumerable<OrderHistoryItem> GetActionsByOrder(Order order)
        {
            var res = from item in history
                      where item.Order == order
                      select item;

            return res;
        }

        public IEnumerable<OrderHistoryItem> GetActionsByPeriodOfTime(DateTime since, DateTime to)
        {
            var res = from item in history
                    where item.Time >= since && item.Time <= to                    
                    select item;

            return res;
        }
    }
}
