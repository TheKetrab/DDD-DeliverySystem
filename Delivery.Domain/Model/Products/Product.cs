using Delivery.Generic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Domain.Model.Products
{
    public class Product : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal DeliveryCost { get; set; }
        public float Weight { get; set; }
        public string Description { get; set; }

    }
}
