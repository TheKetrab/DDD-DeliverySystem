using System;
using System.Collections.Generic;
using System.Text;
using Delivery.Domain.Model.Products;
using Delivery.Domain.Model.Products.Repositories;

namespace Delivery.Infrastructure.Repositories
{
    public class ProductIM : IProductRepository
    {
        List<Product> products;

        public ProductIM()
        {
            products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Laptop", DeliveryCost = 120.99m, Weight = 3 },
                new Product() { Id = 2, Name = "Termistor", DeliveryCost = 4.12m, Weight = 0.0023f },
                new Product() { Id = 3, Name = "Kaloryfer", DeliveryCost = 330.12m, Weight = 18 },
                new Product() { Id = 4, Name = "Lampka nocna", DeliveryCost = 7.33m, Weight = 1.25f },
                new Product() { Id = 5, Name = "Rower", DeliveryCost = 17.12m, Weight = 15.63f }
            };
        }

        public void Delete(int id)
        {
            products.RemoveAt(id);
        }

        public Product Find(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public IEnumerable<Product> FindAll()
        {
            return new List<Product>(products);
        }

        public void Insert(Product product)
        {
            products.Add(product);
        }

    }
}
