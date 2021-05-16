using System;
using System.Collections.Generic;
using System.Text;

using Delivery.Domain.Model.Orders;

namespace Delivery.ObjectMothers
{
    public class OrderObjectMother
    {
        public static Order CreateEmptyOrder()
        {
            Random rnd = new Random();

            return new Order
            {
                Id = rnd.Next(1, 10000),
                DeliveryAddress = AddressObjectMother.CreateRandomAddress(),
                LatestDeliveryDate = DateTime.Now.AddDays(rnd.Next(-1000, 1000)),
                Owner = ClientObjectMother.CreateRandomUser(),
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
