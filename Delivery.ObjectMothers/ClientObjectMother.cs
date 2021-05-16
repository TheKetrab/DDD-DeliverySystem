using System;
using System.Collections.Generic;
using System.Text;

using Delivery.Domain.Model.Clients;

namespace Delivery.ObjectMothers
{
    public class ClientObjectMother
    {
        public static Client CreateRandomUser()
        {
            Random rnd = new Random();

            return new Client
            {
                Address = AddressObjectMother.CreateRandomAddress(),
                Email = "abc@gmail.com",
                Hash = "",
                Name = "",
                Phone = "",
                Role = Role.User
            };
        }

        public static Client CreateUserWithRole(Role role)
        {
            Client client = CreateRandomUser();
            client.Role = role;
            return client;
        }
    }
}
