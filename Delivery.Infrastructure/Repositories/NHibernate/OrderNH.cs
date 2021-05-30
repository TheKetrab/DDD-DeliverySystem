using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Orders;
using Delivery.Domain.Model.Orders.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delivery.Infrastructure.Repositories.NHibernate
{
    public class OrderNH : BaseImplNH<Order>, IOrderRepository
    {
        public override string Table => "Order";
        public IEnumerable<Order> GetOrdersByClient(Client c)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
