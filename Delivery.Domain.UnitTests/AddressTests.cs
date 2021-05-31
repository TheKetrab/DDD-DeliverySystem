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
            int newId = 6039732;
            var addresses = RepositoryObjectMother.CreateAddressRepository();
            var address = AddressObjectMother.CreateAddress(newId);

            // Act
            addresses.Insert(address);
            int givenId = address.Id;

            // Assert
            Assert.AreEqual(address, addresses.Find(givenId));
        }

        [TestMethod]
        public void UpdateAddress()
        {
            // Arrange
            int id = 3;
            var addresses = RepositoryObjectMother.CreateAddressRepository();
            var address = addresses.Find(id);

            string city = "Wilno";
            string street = "Olszowska";
            string nr = "333";

            // Act
            address.City = city;
            address.Street = street;
            address.Nr = nr;
            addresses.Update(address);

            // Assert
            Assert.AreEqual(city, addresses.Find(id).City);
            Assert.AreEqual(street, addresses.Find(id).Street);
            Assert.AreEqual(nr, addresses.Find(id).Nr);
        }

        [TestMethod]
        public void DeleteClient()
        {
            // Arrange
            int id = 8;
            var addresses = RepositoryObjectMother.CreateAddressRepository();
            var address = addresses.Find(id);

            // Act
            addresses.Delete(address);

            // Assert
            Assert.IsNull(addresses.Find(id));
        }
    }
}
