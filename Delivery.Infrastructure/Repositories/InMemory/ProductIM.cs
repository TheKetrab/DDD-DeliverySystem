using System;
using System.Collections.Generic;
using System.Text;
using Delivery.Domain.Model.Products;
using Delivery.Domain.Model.Products.Repositories;

using static Delivery.Generic.Utils.Randoms;

namespace Delivery.Infrastructure.Repositories.InMemory
{
    public class ProductIM : IProductRepository
    {
        List<Product> products;

        public int Count => products.Count;

        public ProductIM(int cnt = 0)
        {
            products = new List<Product>();
            for (int i = 1; i <= cnt; i++)
                products.Add(new Product
                {
                    Id = i,
                    Name = "Product" + i,
                    DeliveryCost = (decimal)RandomDouble(0.5, 25),
                    Weight = (float)RandomDouble(0.05, 100)
                });
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

        public void DeleteAll()
        {
            products.RemoveAll(x => true);
        }

    }
}
