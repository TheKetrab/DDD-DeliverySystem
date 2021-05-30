using Delivery.Domain.Model.Addresses;
using Delivery.Domain.Model.Addresses.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

using static Delivery.Generic.Utils.Randoms;

using System.Linq;
using Delivery.Generic.Interfaces;

namespace Delivery.Infrastructure.Repositories.InMemory
{
    public class AddressIM : BaseImplIM<Address>, IAddressRepository
    {
        private List<Address> addresses;
        private List<Nation> nations;

        public AddressIM(int addressesCnt = 0)
        {
            nations = new List<Nation>()
            {
                new Nation() { Id = 1, Name = "Polska" },
                new Nation() { Id = 2, Name = "Stany Zjednoczone" },
                new Nation() { Id = 3, Name = "Norwegia" },
                new Nation() { Id = 4, Name = "Niemcy" },
                new Nation() { Id = 5, Name = "Słowacja" },
            };

            addresses = _entities;
            for (int i = 1; i <= addressesCnt+1; i++)
                addresses.Add(new Address
                {
                    Id = i,
                    Nation = nations[RandomInt(0, nations.Count-1)],
                    City = RandomCity(),
                    Nr = RandomInt(1, 10000).ToString(),
                    Street = RandomStreet(),
                    ZipCode = RandomZipCode()
                });
                    
        }
    }
}
