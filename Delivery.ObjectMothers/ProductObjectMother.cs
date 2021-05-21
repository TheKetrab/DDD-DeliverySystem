using System;
using System.Collections.Generic;
using System.Text;

using Delivery.Domain.Model.Products;

namespace Delivery.ObjectMothers
{
    public class ProductObjectMother
    {
        public static Product CreateProduct(int id = -1)
        {
            return new Product
            {
                Id = id < 0 ? 1 : id,
                Name = "Item 1",
                DeliveryCost = 48.12m,
                Description = "Simple description",
                Weight = 3f
            };
        }

        public static IEnumerable<Product> CreateManyProducts(int count)
        {
            List<Product> products = new List<Product>();

            for (int i = 0; i < count; i++)
                products.Add(CreateProduct());

            return products;
        }
    }
}
