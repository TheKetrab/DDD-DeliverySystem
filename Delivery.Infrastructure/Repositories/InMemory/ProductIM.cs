using System;
using System.Collections.Generic;
using System.Text;
using Delivery.Domain.Model.Products;
using Delivery.Domain.Model.Products.Repositories;

using static Delivery.Generic.Utils.Randoms;

namespace Delivery.Infrastructure.Repositories.InMemory
{
    public class ProductIM : BaseImplIM<Product>, IProductRepository
    {
        List<Product> products;

        public ProductIM(int cnt = 0)
        {
            products = _entities;
            for (int i = 1; i <= cnt; i++)
                products.Add(new Product
                {
                    Id = i,
                    Name = "Product" + i,
                    DeliveryCost = (decimal)RandomDouble(0.5, 25),
                    Weight = (float)RandomDouble(0.05, 100)
                });
        }


    }
}
