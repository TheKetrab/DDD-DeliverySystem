using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Orders;
using Delivery.Domain.Model.Orders.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Delivery.Domain.Model.Clients.Repositories;
using Delivery.Domain.Model.Addresses.Repositories;

namespace Delivery.Infrastructure.Repositories.MsSql
{
    public class OrderMsSql : IOrderRepository
    {
        public int Count => throw new NotImplementedException();

        public void Delete(int id)
        {
            MsSqlConnector.Instance.Connection.Query(
                "DELETE * FROM Orders WHERE Id = @id", new { id });
        }

        public void DeleteAll()
        {
            MsSqlConnector.Instance.Connection.Query("DELETE * FROM Orders");
        }

        public Order Find(int id)
        {
            Order o = MsSqlConnector.Instance.Connection.QuerySingle<Order>(
                "SELECT * FROM Orders WHERE Id = @id", new { id });

            if (o == null)
                throw new Exception();

            // FOREIGN KEYS MAPPING
            var p = MsSqlConnector.Instance.Connection.QuerySingle<Tuple<int,int>>(
                "SELECT DeliveryAddressId as Item1, OwnerId as Item2 FROM Orders WHERE Id = @id", new { id });

            IClientRepository cRepo = new ClientMsSql();
            IAddressRepository aRepo = new AddressMsSql();

            o.DeliveryAddress = aRepo.Find(p.Item1);
            o.Owner = cRepo.Find(p.Item2);

            return o;
        }

        public IEnumerable<Order> FindAll()
        {
            var res = MsSqlConnector.Instance.Connection
                .Query<Order>("SELECT * FROM Orders");

            return res;
        }

        public IEnumerable<Order> GetOrdersByClient(Client c)
        {
            var orders = MsSqlConnector.Instance.Connection.Query<Order>(
                "SELECT * FROM Orders WHERE OwnerId = @id", new { id = c.Id });

            IOrderRepository orderRepository = new OrderMsSql();

            var res = new List<Order>();
            foreach (var o in orders)
                res.Add(orderRepository.Find(o.Id));

            return res;
        }

        public void Insert(Order item)
        {
            int statusid = MsSqlConnector.Instance.Connection.ExecuteScalar<int>(
                "SELECT * FROM OrderStatus WHERE Status LIKE @status",
                new { status = item.Status.ToString() }
            );

            MsSqlConnector.Instance.Connection.Execute(
               "INSERT INTO Orders(DeliveryAddressId,OwnerId,Status,LatestDate) " +
               "VALUES (@daid, @ownerid, @statusid, @latestdate)",
               new
               {
                   daid = item.DeliveryAddress.Id,
                   ownerid = item.Owner.Id,
                   statusid,
                   item.LatestDeliveryDate
               });

        }
    }
}
