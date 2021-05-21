using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Orders;
using Delivery.Domain.Model.Orders.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace Delivery.Infrastructure.Repositories.MsSql
{
    public class OrderMsSql : IOrderRepository
    {
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
            var res = MsSqlConnector.Instance.Connection.Query<Order>(
                "SELECT * FROM Orders WHERE Id = @id", new { id }).AsList();

            if (res.Count == 0)
                throw new Exception();

            return res[0];

        }

        public IEnumerable<Order> FindAll()
        {
            var res = MsSqlConnector.Instance.Connection
                .Query<Order>("SELECT * FROM Orders");

            return res;
        }

        public IEnumerable<Order> GetClientOrders(Client c)
        {
            var res = MsSqlConnector.Instance.Connection.Query<Order>(
                "SELECT * FROM Orders WHERE OwnerId = @id", new { id = c.Id });

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
