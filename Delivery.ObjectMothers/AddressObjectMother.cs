using System;

using Delivery.Domain.Model.Addresses;

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

        public static Address CreateRandomAddress()
        {
            Random rnd = new Random();

            return new Address
            {
                Id = rnd.Next(1, 1000),
                City = RandomCities[rnd.Next(0, RandomCities.Length-1)],
                Nation = new Nation { Id = 1, Name = "Polska" },
                Nr = rnd.Next(1, 500).ToString(),
                Street = RandomStreets[rnd.Next(0, RandomStreets.Length-1)],
                ZipCode = rnd.Next(10000, 99999).ToString().Insert(2, "-")
            };
        }

    }
}
