using System;
using System.Collections.Generic;
using System.Text;


using Delivery.Domain.Model.Addresses;
using Delivery.Generic.Interfaces;
using Delivery.Generic.Security;

namespace Delivery.Domain.Model.Clients
{
    public class Client : Entity
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public Role Role { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }

        public void SetPassword(string password)
        {
            Hash = Encryption.ComputeHexStringHash(password);
        }

    }
}
