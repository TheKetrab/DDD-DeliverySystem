using Dapper;
using Delivery.Domain.Model.Addresses;
using Delivery.Domain.Model.Addresses.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Infrastructure.Repositories.MsSql
{
    public class AddressMsSql : IAddressRepository
    {
        public int Count
        {
            get
            {
                int cnt = MsSqlConnector.Instance.Connection.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM Addresses");

                return cnt;
            }
        }


        public void Delete(int id)
        {
            MsSqlConnector.Instance.Connection.Query(
                "DELETE * FROM Addresses WHERE Id = @id", new { id });
        }

        public void DeleteAll()
        {
            MsSqlConnector.Instance.Connection.Query("DELETE * FROM Addresses");
        }

        public Address Find(int id)
        {
            var res = MsSqlConnector.Instance.Connection.Query<Address>(
                "SELECT * FROM Addresses WHERE Id = @id", new { id }).AsList();

            if (res.Count == 0)
                throw new Exception();

            return res[0];
        }


        public IEnumerable<Address> FindAll()
        {
            var res = MsSqlConnector.Instance.Connection
                .Query<Address>("SELECT * FROM Addresses");

            return res;
        }

        public void Insert(Address item)
        {
            MsSqlConnector.Instance.Connection.Execute(
                "INSERT INTO Addresses(NationId,City,Street,Nr,ZipCode) " +
                "VALUES (@nation, @city, @street, @nr, @zipcode)",
                new { nation = item.Nation.Id, item.City, item.Street, item.Nr, item.ZipCode });
        }
    }
}
