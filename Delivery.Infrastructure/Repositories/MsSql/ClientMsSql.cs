using Dapper;
using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Clients.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Delivery.Generic.Security;
using Delivery.Domain.Model.Addresses.Repositories;
using System.Linq;

namespace Delivery.Infrastructure.Repositories.MsSql
{
    public class ClientMsSql : BaseImplMsSql<Client>, IClientRepository
    {

        string clientsTN;

        public override string Table => clientsTN;


        public ClientMsSql(string clientsTN = "Clients")
        {
            this.clientsTN = clientsTN;
        }

        public override Client Find(int id)
        {
            Client c = base.Find(id);

            if (c == null)
                throw new Exception();

            // FOREIGN KEYS MAPPING
            var fk = MsSqlConnector.Instance.Connection.QuerySingle<Tuple<int,int>>(
                "SELECT Role AS Item1, AddressId AS Item2 FROM " + clientsTN + " WHERE Id = @id", new { id });

            c.Role = (Role)(fk.Item1);

            IAddressRepository addresses = new AddressMsSql();
            c.Address = addresses.Find(fk.Item2);

            return c;
        }

        public override IQueryable<Client> FindAll()
        {
            var clients = MsSqlConnector.Instance.Connection
                .Query<Client>("SELECT * FROM " + clientsTN);

            var res = new List<Client>();
            foreach (var c in clients)
                res.Add(Find(c.Id));

            return res.AsQueryable();
        }

        public Client GetClientByEmail(string email)
        {
            var res = MsSqlConnector.Instance.Connection.QuerySingle<Client>(
                "SELECT * FROM " + clientsTN + " WHERE Email LIKE @email", new { email });

            return res;

        }

        public override void Insert(Client client)
        {
            MsSqlConnector.Instance.Connection.Execute(
                "INSERT INTO " + clientsTN + "(Name,Email,Hash,Role,AddressId,Phone) " +
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

        public override void Update(Client entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(IList<Client> entities)
        {
            throw new NotImplementedException();
        }
    }
}
