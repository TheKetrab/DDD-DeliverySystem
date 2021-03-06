using System;
using System.Collections.Generic;
using System.Text;
using Delivery.Domain.Model.Orders;
using Delivery.Domain.Model.Orders.Repositories;
using Delivery.Domain.Model.Addresses.Repositories;
using Delivery.Domain.Model.Clients.Repositories;
using Delivery.Domain.Model.Clients;
using System.Linq;
using static Delivery.Generic.Utils.Randoms;

namespace Delivery.Infrastructure.Repositories.InMemory
{
    public class OrderIM : BaseImplIM<Order>, IOrderRepository
    {
        List<Order> orders;

        public OrderIM(IAddressRepository addresses, IClientRepository clients, int ordersCnt = 0)
        {
            orders = _entities;
            for (int i = 1; i <= ordersCnt; i++)
                orders.Add(new Order
                {
                    Id = i,
                    DeliveryAddress = addresses.Find(RandomInt(1,addresses.Count)),
                    LatestDeliveryDate = DateTime.Now.AddDays(RandomInt(-100,100)),
                    Owner = clients.Find(RandomInt(1,clients.Count)),
                    Status = (Status)(RandomInt(0,5))
                });
        }

        public IEnumerable<Order> GetOrdersByClient(Client c)
        {
            var res = from o in orders
                      where o.Owner == c
                      select o;

            return res;
        }

    }
}
