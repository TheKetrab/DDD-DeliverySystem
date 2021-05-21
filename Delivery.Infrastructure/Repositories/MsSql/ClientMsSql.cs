using Dapper;
using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Clients.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Delivery.Generic.Security;

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
            MsSqlConnector.Instance.Connection.Query(
                "DELETE * FROM Clients WHERE Id = @id", new { id });
        }

        public void DeleteAll()
        {
            MsSqlConnector.Instance.Connection.Query("DELETE * FROM Clients");
        }

        public Client Find(int id)
        {
            var res = MsSqlConnector.Instance.Connection.Query<Client>(
                "SELECT * FROM Clients WHERE Id = @id", new { id }).AsList();

            if (res.Count == 0)
                throw new Exception();

            return res[0];
        }

        public IEnumerable<Client> FindAll()
        {
            var res = MsSqlConnector.Instance.Connection
                .Query<Client>("SELECT * FROM Clients");

            return res;
        }

        public Client GetClientByEmail(string email)
        {
            var res = MsSqlConnector.Instance.Connection.Query<Client>(
                "SELECT * FROM Clients WHERE Email LIKE @email", new { email }).AsList();

            if (res.Count == 0)
                throw new Exception();

            return res[0];

        }

        public void Insert(Client client)
        {
            MsSqlConnector.Instance.Connection.Execute(
                "INSERT INTO Clients(Name,Email,Hash,Role,AddressId,Phone) " +
                "VALUES (@name, @email, @hash, @role, @address, @phone)",
                new { client.Name, client.Email, client.Hash,
                    client.Role, client.Address, client.Phone });
        }

        public void SetPassword(Client client, string password)
        {
            string hash = Encryption.ComputeHexStringHash(password);

            MsSqlConnector.Instance.Connection.Execute(
                "UPDATE Clients SET Hash = @hash WHERE Id = @id",
                new { hash, client.Id }
            );

        }

        public void SetRole(Client client, Role role)
        {
            string roleName = role.ToString();

            int roleId = MsSqlConnector.Instance.Connection.ExecuteScalar<int>(
                "SELECT Id FROM ClientRole WHERE Name LIKE '@name'", new { name = roleName });

            MsSqlConnector.Instance.Connection.Execute(
                "UPDATE Clients SET Role = @roleid WHERE Id = @id",
                new { roleid = roleId, id = client.Id }
            );
        }
    }
}
