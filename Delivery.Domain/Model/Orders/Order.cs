﻿using System;
using System.Collections.Generic;
using System.Text;
using Delivery.Domain.Model.Addresses;
using Delivery.Domain.Model.Clients;

namespace Delivery.Domain.Model.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public Address DeliveryAddress { get; set; }
        public Client Owner { get; set; }
        public Status Status { get; set; }
        public DateTime LatestDeliveryDate { get; set; }

    }
}
