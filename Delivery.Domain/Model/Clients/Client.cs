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
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Hash { get; set; }
        public virtual Role Role { get; set; }
        public virtual Address Address { get; set; }
        public virtual string Phone { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1}) ({2})", Name, Email, Role);
        }

        public void SetPassword(string password)
        {
            Hash = Encryption.ComputeHexStringHash(password);
        }

    }
}
