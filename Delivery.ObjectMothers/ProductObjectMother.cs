using System;
using System.Collections.Generic;
using System.Text;

using Delivery.Domain.Model.Products;

namespace Delivery.ObjectMothers
{
    public class ProductObjectMother
    {
        private static Random rnd = new Random();

        private static string[] ProductNames = {
            "Gitara", "Samochód", "Komputer", "Kartka", "Szklanka",
            "Telefon", "Długopis", "Myszka", "Szafka", "Lampka",
            "Łóżko", "Szafa", "Stół", "Zbiór zadań", "Szyba", "Słoik"
        };

        public static Product CreateRandomProduct()
        {
            return new Product
            {
                Id = rnd.Next(1, 1000000),
                Name = ProductNames[rnd.Next(0, ProductNames.Length - 1)] + " " + rnd.Next(1, 100).ToString(),
                DeliveryCost = (decimal)(rnd.NextDouble() * 1000),
                Description = "",
                Weight = (float)(rnd.NextDouble() * 50)
            };
        }

        public static IEnumerable<Product> CreateManyProducts(int count)
        {
            List<Product> products = new List<Product>();

            for (int i = 0; i < count; i++)
                products.Add(CreateRandomProduct());

            return products;
        }
    }
}
