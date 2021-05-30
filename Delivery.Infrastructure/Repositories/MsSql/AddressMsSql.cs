using Dapper;
using Delivery.Domain.Model.Addresses;
using Delivery.Domain.Model.Addresses.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Infrastructure.Repositories.MsSql
{
    public class AddressMsSql : BaseImplMsSql<Address>, IAddressRepository
    {
        string addressesTN;
        string nationsTN;

        public override string Table => addressesTN;

        public AddressMsSql(string addressesTN = "Addresses", string nationsTN = "Nations")
        {
            this.addressesTN = addressesTN;
            this.nationsTN = nationsTN;
        }

        public override Address Find(int id)
        {
            Address a = base.Find(id);
            if (a == null)
                throw new Exception();

            // FOREIGN KEYS MAPPING
            int nationId = MsSqlConnector.Instance.Connection.ExecuteScalar<int>(
                "SELECT NationId FROM " + addressesTN + " WHERE Id = @id", new { id });

            Nation nation = MsSqlConnector.Instance.Connection.QuerySingle<Nation>(
                "SELECT * FROM " + nationsTN + " WHERE Id = @nationId", new { nationId });

            a.Nation = nation;

            return a;
        }

        public override void Insert(Address item)
        {
            MsSqlConnector.Instance.Connection.Execute(
                "INSERT INTO " + addressesTN + "(NationId,City,Street,Nr,ZipCode) " +
                "VALUES (@nation, @city, @street, @nr, @zipcode)",
                new { 
                    nation = item.Nation.Id,
                    city = item.City,
                    street = item.Street,
                    nr = item.Nr,
                    zipcode = item.ZipCode 
                });
        }

        public override void Update(Address entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(IList<Address> entities)
        {
            throw new NotImplementedException();
        }
    }
}
