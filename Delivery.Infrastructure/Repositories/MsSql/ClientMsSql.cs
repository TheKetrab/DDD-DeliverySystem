using Dapper;
using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Clients.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Delivery.Generic.Security;
using Delivery.Domain.Model.Addresses.Repositories;

namespace Delivery.Infrastructure.Repositories.MsSql
{
    public class ClientMsSql : IClientRepository
    {
        public int Count
        {
            get
            {
                int cnt = MsSqlConnector.Instance.Connection.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM Clients");

                return cnt;
            }
        }


        public void Delete(int id)
        {
            MsSqlConnector.Instance.Connection.Execute(
                "DELETE * FROM Clients WHERE Id = @id", new { id });
        }

        public void DeleteAll()
        {
            MsSqlConnector.Instance.Connection.Execute("DELETE * FROM Clients");
        }

        public Client Find(int id)
        {
            Client c = MsSqlConnector.Instance.Connection.QuerySingle<Client>(
                "SELECT * FROM Clients WHERE Id = @id", new { id });

            if (c == null)
                throw new Exception();

            // FOREIGN KEYS MAPPING
            var fk = MsSqlConnector.Instance.Connection.QuerySingle<Tuple<int,int>>(
                "SELECT Role AS Item1, AddressId AS Item2 FROM Clients WHERE Id = @id", new { id });

            c.Role = (Role)(fk.Item1);

            IAddressRepository addresses = new AddressMsSql();
            c.Address = addresses.Find(fk.Item2);

            return c;
        }

        public IEnumerable<Client> FindAll()
        {
            var clients = MsSqlConnector.Instance.Connection
                .Query<Client>("SELECT * FROM Clients");

            var res = new List<Client>();
            foreach (var c in clients)
                res.Add(Find(c.Id));

            return res;
        }

        public Client GetClientByEmail(string email)
        {
            var res = MsSqlConnector.Instance.Connection.Query<Client>(
                "SELECT * FROM Clients WHERE Email LIKE @email", new { email }).AsList();

            if (res.Count == 0)
                throw new Exception();

            return Find(res[0].Id);

        }

        public void Insert(Client client)
        {
            MsSqlConnector.Instance.Connection.Execute(
                "INSERT INTO Clients(Name,Email,Hash,Role,AddressId,Phone) " +
                "VALUES (@name, @email, @hash, @role, @address, @phone)",
                new { 
                    name = client.Name,
                    email = client.Email,
                    hash = client.Hash,
                    role = (int)(client.Role),
                    address = client.Address.Id,
                    phone = client.Phone 
                });
        }

    }
}
