using System;
using System.Collections.Generic;
using Delivery.Domain.Model.Clients;

namespace Delivery.Domain.Model.Orders
{
    public class OrderHistoryItem
    {
        public Client Client;
        public Order Order;
        public OrderAction Action;
        public string Description;
        public DateTime Time;
    }

}
