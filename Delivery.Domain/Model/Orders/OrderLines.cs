using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Domain.Model.Orders
{
    class OrderLines
    {
        public Dictionary<Order, OrderLine> Lines { get; set; }
    }
}
