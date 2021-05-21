using System;
using System.Collections.Generic;
using System.Text;
using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Clients.Repositories;
using Delivery.Domain.Model.Addresses.Repositories;
using Delivery.Generic.Security;
using Delivery.Generic.Security;

using static Delivery.Generic.Utils.Randoms;

namespace Delivery.Infrastructure.Repositories.InMemory
{
    public class ClientIM : IClientRepository
    {
        List<Client> clients;

        public int Count => clients.Count;

        public ClientIM(IAddressRepository addresses, int clientsCnt = 0)
        {
            clients = new List<Client>();
            for (int i = 1; i <= clientsCnt; i++)
                clients.Add(new Client
                {
                    Id = i,
                    Name = "Client" + i,
                    Email = RandomString(10) + "@gmail.com",
                    Role = Role.User,
                    Hash = Encryption.ComputeHexStringHash("abc"), // Password is: abc
                    Address = addresses.Find(RandomInt(1, addresses.Count)),
                    Phone = RandomPhoneNumber()
                });
        }

        public void Delete(int id)
        {
            Client client = Find(id);
            clients.Remove(client);
        }

        public Client Find(int id)
        {
            return clients.Find(c => c.Id == id);
        }

        public IEnumerable<Client> FindAll()
        {
            return new List<Client>(clients);
        }

        public Client GetClientByEmail(string email)
        {
            return clients.Find(c => c.Email == email);
        }

        public void Insert(Client client)
        {
            clients.Add(client);
        }

        public void SetPassword(Client client, string password)
        {
            client.Hash = Encryption.ComputeHexStringHash(password);
        }

        public void SetRole(Client client, Role role)
        {
            var cl = clients.Find(c => c.Id == client.Id);
            cl.Role = role;
        }

        public void DeleteAll()
        {
            clients.RemoveAll(x => true);
        }
    }
}
