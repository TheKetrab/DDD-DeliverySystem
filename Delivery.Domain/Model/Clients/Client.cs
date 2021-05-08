using System;
using System.Collections.Generic;
using System.Text;

using Delivery.Domain.Model.Addresses;

namespace Delivery.Domain.Model.Clients
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public Role Role { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }

    }
}
