using Delivery.Domain.Model.Addresses;
using Delivery.Infrastructure.Repositories.InMemory;
using Delivery.Domain.Model.Addresses.Repositories;
using static Delivery.Generic.Utils.Randoms;

namespace Delivery.ObjectMothers
{
    public class AddressObjectMother
    {
        private static string[] RandomCities = { 
            "Warszawa", "Nowy Targ", "Wrocław",
            "Katowice", "Gdańsk", "Bielsko-Biała", "Żywiec"
        };

        private static string[] RandomStreets = {
            "Kosmonautów", "Grabiszyńska", "Otmuchowska",
            "Krakowska", "Kwiatowa", "Tulipanów", "Osienicka",
            "Poniatowskiego", "Trzebiatowska", "Spacerowa"
        };

        public static Address CreateRandomAddress(int i = -1)
        {
            return new Address
            {
                Id = (i < 0) ? RandomInt(1, 1000000) : i,
                City = RandomCities[RandomInt(0, RandomCities.Length-1)],
                Nation = new Nation { Id = 1, Name = "Polska" },
                Nr = RandomInt(1, 500).ToString(),
                Street = RandomStreets[RandomInt(0, RandomStreets.Length-1)],
                ZipCode = RandomInt(10000, 99999).ToString().Insert(2, "-")
            };
        }

        public static IAddressRepository CreateRandomAddressRepository(int count = 100)
        {
            AddressIM addresses = new AddressIM();
            addresses.DeleteAll();

            for (int i = 1; i <= count; i++)
                addresses.Insert(CreateRandomAddress(i));

            return addresses;
        }
    }
}
