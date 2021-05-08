using System;
using System.Collections.Generic;
using System.Text;
using Delivery.Domain.Model.Products;

namespace Delivery.Domain.Model.Orders
{
    class OrderLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Bonus { get; set; }
    }
}
