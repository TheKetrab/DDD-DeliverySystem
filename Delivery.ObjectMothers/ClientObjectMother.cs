using System;
using System.Collections.Generic;
using System.Text;

using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Clients.Repositories;
using Delivery.Generic.Utils;
using Delivery.Infrastructure.Repositories.InMemory;

namespace Delivery.ObjectMothers
{
    public class ClientObjectMother
    {
        public static Client CreateUser(int i = -1)
        {
            return new Client
            {
                Id = (i < 0) ? 1 : i,
                Address = RepositoryObjectMother.CreateAddressRepository().Find(1),
                Email = "abc@gmail.com",
                Hash = "HASH",
                Name = "Client" + i,
                Phone = "0123456789",
                Role = Role.User
            };
        }

        public static Client CreateUserWithRole(Role role)
        {
            Client client = CreateUser();
            client.Role = role;
            return client;
        }

        public static IClientRepository CreateClientsRepository(int count = 100)
        {
            AddressIM addresses = new AddressIM();
            ClientIM clients = new ClientIM(addresses);
            clients.DeleteAll();

            for (int i = 1; i <= count; i++)
                clients.Insert(CreateUser(i));

            return clients;
        }
    }
}
