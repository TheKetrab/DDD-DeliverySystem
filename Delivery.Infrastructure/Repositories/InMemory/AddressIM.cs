using Delivery.Domain.Model.Addresses;
using Delivery.Domain.Model.Addresses.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace Delivery.Infrastructure.Repositories.InMemory
{
    public class AddressIM : IAddressRepository
    {
        private List<Address> addresses;
        private List<Nation> nations;

        public AddressIM()
        {
            nations = new List<Nation>()
            {
                new Nation() { Id = 1, Name = "Polska" },
                new Nation() { Id = 2, Name = "Stany Zjednoczone" },
                new Nation() { Id = 3, Name = "Norwegia" },
                new Nation() { Id = 4, Name = "Niemcy" },
                new Nation() { Id = 5, Name = "Słowacja" },
            };

            addresses = new List<Address>
            {
                new Address { Id = 1, Nation = nations[0], City = "Warszawa", Street = "Kilińskiego", Nr = "153/11", ZipCode = "12-445" },
                new Address { Id = 2, Nation = nations[0], City = "Kielce", Street = "Oźnicza", Nr = "12", ZipCode = "01-325" },
                new Address { Id = 3, Nation = nations[0], City = "Oddzierżowice", Street = "Kuźnicza", Nr = "53", ZipCode = "55-525" },
                new Address { Id = 4, Nation = nations[0], City = "Zamość Śląska", Street = "Willamów", Nr = "512", ZipCode = "34-321" },
                new Address { Id = 5, Nation = nations[0], City = "Iława Górna", Street = "Bratki", Nr = "5a", ZipCode = "38-173" },
                new Address { Id = 6, Nation = nations[0], City = "Sopotnia Wielka", Street = "Wodospad", Nr = "16", ZipCode = "88-991" },
                new Address { Id = 7, Nation = nations[0], City = "Dąbki", Street = "Portowa", Nr = "11", ZipCode = "25-123" },
                new Address { Id = 8, Nation = nations[1], City = "New York", Street = "8 Av", Nr = "22-32", ZipCode = "12-11234" },
                new Address { Id = 9, Nation = nations[2], City = "Oslo", Street = "Main Street", Nr = "1A4", ZipCode = "001-2123" },
                new Address { Id = 10, Nation = nations[4], City = "Bratysława", Street = "Marketer", Nr = "577", ZipCode = "0682332" },
            };
                    
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
