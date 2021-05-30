using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Orders;
using Delivery.Domain.Model.Orders.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace Delivery.Infrastructure.Repositories.MsSql
{
    public class OrderHistoryMsSql : IOrderHistoryRepository
    {
        string historyTN;
        string orderActionTN;

        public OrderHistoryMsSql(string historyTN = "History", string orderActionTN = "OrderAction")
        {
            this.historyTN = historyTN;
            this.orderActionTN = orderActionTN;
        }

        public void AddAction(Client client, Order order, OrderAction action, DateTime time = default, string description = "")
        {
            string query =
                "INSERT INTO " + historyTN + "(ClientId, OrderId, Action, Description, Time) " +
                "VALUES(@clientid,@orderid,@actionid,@description,@time)";

            int actionid = MsSqlConnector.Instance.Connection.ExecuteScalar<int>(
                "SELECT Id FROM " + orderActionTN + " WHERE Action LIKE @name", new { name = action.ToString() });

            MsSqlConnector.Instance.Connection.Execute(query,
                new { clientid = client.Id, orderid = order.Id, actionid, description, time });
        }

        public IEnumerable<OrderHistoryItem> GetActionsByClient(Client client)
        {
            var res = MsSqlConnector.Instance.Connection.Query<OrderHistoryItem>(
                "SELECT * FROM " + historyTN + " WHERE ClientId = @id", new { id = client.Id });

            return res;
        }

        public IEnumerable<OrderHistoryItem> GetActionsByOrder(Order order)
        {
            var res = MsSqlConnector.Instance.Connection.Query<OrderHistoryItem>(
                "SELECT * FROM " + historyTN + " WHERE OrderId = @id", new { id = order.Id });

            return res;
        }

        public IEnumerable<OrderHistoryItem> GetActionsByPeriodOfTime(DateTime since, DateTime to)
        {
            var res = MsSqlConnector.Instance.Connection.Query<OrderHistoryItem>(
                "SELECT * FROM " + historyTN + " WHERE Time >= @since AND Time <= to", new { since, to });

            return res;
        }
    }
}
