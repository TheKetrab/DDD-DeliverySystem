using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Delivery.ObjectMothers;
using static Delivery.Generic.Utils.Randoms;

namespace Delivery.Domain.UnitTests
{
    [TestClass]
    public class AddressTests
    {

        [TestMethod]
        public void CreateAddress()
        {
            // Arrange
            int total = 50;
            int newId = total + 1;
            var addresses = AddressObjectMother.CreateAddressRepository(total);
            var address = AddressObjectMother.CreateAddress(newId);

            // Act
            addresses.Insert(address);

            // Assert
            Assert.AreEqual(address, addresses.Find(newId));
        }

        [TestMethod]
        public void UpdateAddress()
        {
            // Arrange
            int total = 50;
            int id = RandomInt(1, total);
            var addresses = AddressObjectMother.CreateAddressRepository(total);
            var address = addresses.Find(id);

            string city = "Wilno";
            string street = "Olszowska";
            string nr = "333";

            // Act
            address.City = city;
            address.Street = street;
            address.Nr = nr;

            // Assert
            Assert.AreEqual(city, addresses.Find(id).City);
            Assert.AreEqual(street, addresses.Find(id).Street);
            Assert.AreEqual(nr, addresses.Find(id).Nr);
        }

        [TestMethod]
        public void DeleteClient()
        {
            // Arrange
            int total = 50;
            int id = RandomInt(1, total);
            var addresses = AddressObjectMother.CreateAddressRepository(total);

            // Act
            addresses.Delete(id);

            // Assert
            Assert.IsNull(addresses.Find(id));
        }
    }
}
