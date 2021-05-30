using Delivery.Generic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Domain.Model.Addresses
{
    public class Address : Entity
    {
        public int Id { get; set; }
        public Nation Nation { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Nr { get; set; }
        public string ZipCode { get; set; }

        public override string ToString()
        {
            return
                string.Format("{0}, {1}, {2}, {3}",
                    ZipCode, City, Street, Nr
                );

        }
    }
}
