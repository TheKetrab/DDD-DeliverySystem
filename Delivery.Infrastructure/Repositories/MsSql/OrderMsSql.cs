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
    public class OrderMsSql : BaseImplMsSql<Order>, IOrderRepository
    {
        string ordersTN;
        string orderStatusTN;

        public override string Table => ordersTN;

        public OrderMsSql(string ordersTN = "Orders", string orderStatusTN = "OrderStatus")
        {
            this.ordersTN = ordersTN;
            this.orderStatusTN = orderStatusTN;
        }

        public override Order Find(int id)
        {
            Order o = base.Find(id);
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

        public IEnumerable<Order> GetOrdersByClient(Client c)
        {
            var orders = MsSqlConnector.Instance.Connection.Query<Order>(
                "SELECT * FROM " + ordersTN + " WHERE OwnerId = @id", new { id = c.Id });

            IOrderRepository orderRepository = new OrderMsSql();

            var res = new List<Order>();
            foreach (var o in orders)
                res.Add(orderRepository.Find(o.Id));

            return res;
        }

        public override void Insert(Order item)
        {
            int statusid = MsSqlConnector.Instance.Connection.ExecuteScalar<int>(
                "SELECT * FROM " + orderStatusTN + " WHERE Status LIKE @status",
                new { status = item.Status.ToString() }
            );

            MsSqlConnector.Instance.Connection.Execute(
               "INSERT INTO " + ordersTN + "(DeliveryAddressId,OwnerId,Status,LatestDate) " +
               "VALUES (@daid, @ownerid, @statusid, @latestdate)",
               new
               {
                   daid = item.DeliveryAddress.Id,
                   ownerid = item.Owner.Id,
                   statusid,
                   item.LatestDeliveryDate
               });

        }

        public override void Update(Order entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(IList<Order> entities)
        {
            throw new NotImplementedException();
        }
    }
}
