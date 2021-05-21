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
            MsSqlConnector.Instance.Connection.Execute(
                "DELETE * FROM Addresses WHERE Id = @id", new { id });
        }

        public void DeleteAll()
        {
            MsSqlConnector.Instance.Connection.Execute("DELETE * FROM Addresses");
        }

        public Address Find(int id)
        {
            Address a = MsSqlConnector.Instance.Connection.QuerySingle<Address>(
                "SELECT * FROM Addresses WHERE Id = @id", new { id });

            if (a == null)
                throw new Exception();

            // FOREIGN KEYS MAPPING
            int nationId = MsSqlConnector.Instance.Connection.ExecuteScalar<int>(
                "SELECT NationId FROM Addresses WHERE Id = @id", new { id });

            Nation nation = MsSqlConnector.Instance.Connection.QuerySingle<Nation>(
                "SELECT * FROM Nations WHERE Id = @nationId", new { nationId });

            a.Nation = nation;

            return a;
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
                new { 
                    nation = item.Nation.Id,
                    city = item.City,
                    street = item.Street,
                    nr = item.Nr,
                    zipcode = item.ZipCode 
                });
        }
    }
}
