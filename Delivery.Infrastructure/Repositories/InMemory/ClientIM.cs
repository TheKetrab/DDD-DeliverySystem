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
    public class ClientIM : BaseImplIM<Client>, IClientRepository
    {
        List<Client> clients;

        public ClientIM(IAddressRepository addresses, int clientsCnt = 0)
        {
            clients = _entities;
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

            // add admin - always
            clients.Add(new Client
            {
                Id = clients.Count + 1,
                Name = "Admin",
                Email = "admin@gmail.com",
                Role = Role.Admin,
                Hash = Encryption.ComputeHexStringHash("abc"), // Password is: abc
                Address = addresses.Find(RandomInt(1, addresses.Count)),
                Phone = RandomPhoneNumber()
            });
        }

        public Client GetClientByEmail(string email)
        {
            return clients.Find(c => c.Email == email);
        }

    }
}
