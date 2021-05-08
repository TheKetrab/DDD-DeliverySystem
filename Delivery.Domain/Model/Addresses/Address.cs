﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Domain.Model.Addresses
{
    public class Address
    {
        public int Id { get; set; }
        public Nation Nation { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Nr { get; set; }
        public string ZipCode { get; set; }

    }
}
