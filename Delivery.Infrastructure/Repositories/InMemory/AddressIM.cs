using Delivery.Domain.Model.Addresses;
using Delivery.Domain.Model.Addresses.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

using static Delivery.Generic.Utils.Randoms;

using System.Linq;

namespace Delivery.Infrastructure.Repositories.InMemory
{
    public class AddressIM : IAddressRepository
    {
        private List<Address> addresses;
        private List<Nation> nations;

        public int Count => addresses.Count;

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

            addresses = new List<Address>();
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

        public void Delete(int id)
        {
            var address = Find(id);
            addresses.Remove(address);
        }

        public Address Find(int id)
        {
            return addresses.Find(a => a.Id == id);
        }

        public IEnumerable<Address> FindAll()
        {
            return new List<Address>(addresses);
        }

        public void Insert(Address address)
        {
            addresses.Add(address);
        }

        public void DeleteAll()
        {
            addresses.RemoveAll(x => true);
        }
    }
}
