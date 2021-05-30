using System;
using System.Collections.Generic;
using System.Text;
using Delivery.Domain.Model.Addresses;
using Delivery.Domain.Model.Clients;
using Delivery.Generic.Interfaces;

namespace Delivery.Domain.Model.Orders
{
    public class Order : Entity
    {
        public override int Id { get; set; }
        public virtual Address DeliveryAddress { get; set; }
        public virtual Client Owner { get; set; }
        public virtual Status Status { get; set; }
        public virtual DateTime LatestDeliveryDate { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}] by {1} up to {2}", 
                Id, Owner.Name, LatestDeliveryDate.ToString("dd/MM/yyyy"));
        }

    }
}
