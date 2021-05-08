using System;
using System.Collections.Generic;
using System.Text;
using Delivery.Domain.Model.Orders;
using Delivery.Domain.Model.Orders.Repositories;
using Delivery.Domain.Model.Addresses.Repositories;
using Delivery.Domain.Model.Clients.Repositories;
using Delivery.Domain.Model.Clients;
using System.Linq;

namespace Delivery.Infrastructure.Repositories
{
    public class OrderIM : IOrderRepository
    {
        List<Order> orders;

        public OrderIM(IAddressRepository addresses, IClientRepository clients)
        {
            orders = new List<Order>()
            {
                new Order()
                {
                    Id = 1,
                    DeliveryAddress = addresses.Find(2),
                    LatestDeliveryDate = new DateTime(2021,7,3),
                    Owner = clients.Find(3),
                    Status = Status.Paid
                },
                new Order()
                {
                    Id = 2,
                    DeliveryAddress = addresses.Find(1),
                    LatestDeliveryDate = new DateTime(2022,1,15),
                    Owner = clients.Find(1),
                    Status = Status.Paid
                },
                new Order()
                {
                    Id = 3,
                    DeliveryAddress = addresses.Find(6),
                    LatestDeliveryDate = new DateTime(2021,7,26),
                    Owner = clients.Find(2),
                    Status = Status.Canceled
                },
                new Order()
                {
                    Id = 4,
                    DeliveryAddress = addresses.Find(7),
                    LatestDeliveryDate = new DateTime(2023,10,30),
                    Owner = clients.Find(1),
                    Status = Status.Inactive
                }
            };
        }

        public void Delete(int id)
        {
            orders.RemoveAt(id);
        }

        public Order Find(int id)
        {
            return orders.Find(o => o.Id == id);
        }

        public IEnumerable<Order> FindAll()
        {
            return new List<Order>(orders);
        }

        public IEnumerable<Order> GetClientOrders(Client c)
        {
            var res = from o in orders
                      where o.Owner == c
                      select o;

            return res;
        }

        public void Insert(Order order)
        {
            orders.Add(order);
        }
    }
}
