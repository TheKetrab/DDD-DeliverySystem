using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Delivery.ObjectMothers;
using Delivery.Generic.Utils;
using Delivery.Generic.Security;
using static Delivery.Generic.Utils.Randoms;

namespace Delivery.Domain.UnitTests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void ChangeClientPassword()
        {
            // Arrange
            var clients = ClientObjectMother.CreateClientsRepository(50);
            string newPassword = RandomString(15);
            int id = 13;

            // Act
            var client = clients.Find(id);
            clients.SetPassword(client, newPassword);

            // Assert
            Assert.AreEqual(
                Encryption.ComputeHexStringHash(newPassword),
                clients.Find(id).Hash
            );
        }

        [TestMethod]
        public void CreateClient()
        {
            // Arrange
            int total = 50;
            int newId = total + 1;
            var clients = ClientObjectMother.CreateClientsRepository(total);
            var client = ClientObjectMother.CreateUser(newId);

            // Act
            clients.Insert(client);

            // Assert
            Assert.AreEqual(client, clients.Find(newId));
        }

        [TestMethod]
        public void UpdateClient()
        {
            // Arrange
            int total = 50;
            int id = RandomInt(1,total);
            var clients = ClientObjectMother.CreateClientsRepository(total);
            var client = clients.Find(id);
            string name = RandomString(30);
            string phone = RandomPhoneNumber();

            // Act
            client.Name = name;
            client.Phone = phone;

            // Assert
            Assert.AreEqual(name, clients.Find(id).Name);
            Assert.AreEqual(phone, clients.Find(id).Phone);
        }

        [TestMethod]
        public void DeleteClient()
        {
            // Arrange
            int total = 50;
            int id = RandomInt(1, total);
            var clients = ClientObjectMother.CreateClientsRepository(total);

            // Act
            clients.Delete(id);

            // Assert
            Assert.IsNull(clients.Find(id));
        }


    }
}
