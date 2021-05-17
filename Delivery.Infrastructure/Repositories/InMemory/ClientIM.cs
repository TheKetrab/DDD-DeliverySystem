using System;
using System.Collections.Generic;
using System.Text;
using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Clients.Repositories;
using Delivery.Domain.Model.Addresses.Repositories;
using Delivery.Generic.Security;

namespace Delivery.Infrastructure.Repositories.InMemory
{
    public class ClientIM : IClientRepository
    {
        List<Client> clients;

        public ClientIM(IAddressRepository addresses)
        {
            clients = new List<Client>()
            {
                new Client()
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "theadmin@xyz.pl",
                    Role = Role.Admin,
                    Hash = "4b8bce88d4963bee06eb985fed7c3266",
                    Address = addresses.Find(1),
                    Phone = "+1-202-555-0195"
                },
                new Client()
                {
                    Id = 2,
                    Name = "Rowerowo PL",
                    Email = "simpleMail1@gmail.com",
                    Role = Role.Moderator,
                    Hash = "eceb68139feb48ee5bedd74c8ca32c76",
                    Address = addresses.Find(2),
                    Phone = "+1-202-555-0184"
                },
                new Client()
                {
                    Id = 3,
                    Name = "Axy Alpha",
                    Email = "laptopbest@aa.nl",
                    Role = Role.User,
                    Hash = "00847eb043aba329f6ff05972ede0263",
                    Address = addresses.Find(6),
                    Phone = "+48 579 564 398"
                },
                new Client()
                {
                    Id = 4,
                    Name = "Sir Patrick Company",
                    Email = "dellit@on.it",
                    Role = Role.PremiumUser,
                    Hash = "75d5ad4389fb134374103d8cc03a8ba8",
                    Address = addresses.Find(7),
                    Phone = "+48 727 842 501"
                }
            };
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
            client.Hash = Encryption.ComputeUtf8StringHash(password);
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
