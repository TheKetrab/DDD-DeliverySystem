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
        public static Client CreateRandomUser(int i = -1)
        {
            return new Client
            {
                Id = (i < 0) ? Randoms.RandomInt(1,1000000) : i,
                Address = AddressObjectMother.CreateRandomAddress(),
                Email = "abc@gmail.com",
                Hash = "",
                Name = "",
                Phone = "",
                Role = Role.User
            };
        }

        public static Client CreateRandomUserWithRole(Role role)
        {
            Client client = CreateRandomUser();
            client.Role = role;
            return client;
        }

        public static IClientRepository CreateRandomClientsRepository(int count = 100)
        {
            AddressIM addresses = new AddressIM();
            ClientIM clients = new ClientIM(addresses);
            clients.DeleteAll();

            for (int i = 1; i <= count; i++)
                clients.Insert(CreateRandomUser(i));

            return clients;
        }
    }
}
