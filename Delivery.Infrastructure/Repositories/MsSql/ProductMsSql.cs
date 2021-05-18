using Delivery.Domain.Model.Products;
using Delivery.Domain.Model.Products.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace Delivery.Infrastructure.Repositories.MsSql
{
    public class ProductMsSql : IProductRepository
    {
        public void Delete(int id)
        {
            MsSqlConnector.Instance.Connection.Query(
                "DELETE * FROM Products WHERE Id = @id", new { id });
        }

        public void DeleteAll()
        {
            MsSqlConnector.Instance.Connection.Query("DELETE * FROM Products");
        }

        public Product Find(int id)
        {
            var res = MsSqlConnector.Instance.Connection.Query<Product>(
                "SELECT * FROM Products WHERE Id = @id", new { id }).AsList();

            if (res.Count == 0)
                throw new Exception();

            return res[0];
        }

        public IEnumerable<Product> FindAll()
        {
            var res = MsSqlConnector.Instance.Connection
                .Query<Product>("SELECT * FROM Products");

            return res;
        }

        public void Insert(Product item)
        {
            MsSqlConnector.Instance.Connection.Execute(
               "INSERT INTO Products(Name,DeliveryCost,Weight,Description) " +
               "VALUES (@name, @cost, @weight, @description)",
               new
               {
                   name = item.Name,
                   cost = item.DeliveryCost,
                   weight = item.Weight,
                   description = item.Description
               });
        }
    }
}
