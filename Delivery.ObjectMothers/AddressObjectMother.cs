using Delivery.Domain.Model.Addresses;
using Delivery.Infrastructure.Repositories.InMemory;
using Delivery.Domain.Model.Addresses.Repositories;
using static Delivery.Generic.Utils.Randoms;

namespace Delivery.ObjectMothers
{
    public class AddressObjectMother
    {

        public static Address CreateAddress(int i = -1)
        {
            return new Address
            {
                Id = (i < 0) ? 1 : i,
                City = "Warszawa",
                Nation = new Nation { Id = 1, Name = "Polska" },
                Nr = "32",
                Street = "TheStreet",
                ZipCode = "01-234"
            };
        }

        public static IAddressRepository CreateAddressRepository(int count = 100)
        {
            AddressIM addresses = new AddressIM();
            addresses.DeleteAll();

            for (int i = 1; i <= count; i++)
                addresses.Insert(CreateAddress(i));

            return addresses;
        }
    }
}
