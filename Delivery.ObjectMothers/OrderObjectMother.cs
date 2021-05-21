using System;
using System.Collections.Generic;
using System.Text;

using Delivery.Domain.Model.Orders;

namespace Delivery.ObjectMothers
{
    public class OrderObjectMother
    {
        public static Order CreateEmptyOrder(int id = -1)
        {
            return new Order
            {
                Id = (id < 0) ? 1 : id,
                DeliveryAddress = AddressObjectMother.CreateAddress(),
                LatestDeliveryDate = DateTime.Now.AddDays(5),
                Owner = ClientObjectMother.CreateUser(),
                Status = Status.Inactive
            };
        }

        public static IEnumerable<OrderHistoryItem> CreateOrderHistory()
        {
            return new List<OrderHistoryItem>()
            { 
                // TODO
            };
        }
    }
}
