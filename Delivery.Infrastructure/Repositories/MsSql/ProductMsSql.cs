using Delivery.Domain.Model.Products;
using Delivery.Domain.Model.Products.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace Delivery.Infrastructure.Repositories.MsSql
{
    public class ProductMsSql : BaseImplMsSql<Product>, IProductRepository
    {
        string productsTN;
        public override string Table => productsTN;

        public ProductMsSql(string productsTN = "Products")
        {
            this.productsTN = productsTN;
        }

        public override void Insert(Product item)
        {
            MsSqlConnector.Instance.Connection.Execute(
               "INSERT INTO " + productsTN + "(Name,DeliveryCost,Weight,Description) " +
               "VALUES (@name, @cost, @weight, @description)",
               new
               {
                   name = item.Name,
                   cost = item.DeliveryCost,
                   weight = item.Weight,
                   description = item.Description
               });
        }

        public override void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(IList<Product> entities)
        {
            throw new NotImplementedException();
        }
    }
}
