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
            var clients = RepositoryObjectMother.CreateClientRepository();
            string newPassword = RandomString(15);
            int id = 5;

            // Act
            var client = clients.Find(id);
            client.SetPassword(newPassword);
            clients.Update(client); // save changes

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
            int newId = 16337;
            var clients = RepositoryObjectMother.CreateClientRepository();
            var client = ClientObjectMother.CreateUser(newId);

            // Act
            clients.Insert(client);
            int givenId = client.Id;

            // Assert
            Assert.AreEqual(client, clients.Find(givenId));
        }

        [TestMethod]
        public void UpdateClient()
        {
            // Arrange
            int id = 3;
            var clients = RepositoryObjectMother.CreateClientRepository();
            var client = clients.Find(id);
            string name = RandomString(30);
            string phone = RandomPhoneNumber();

            // Act
            client.Name = name;
            client.Phone = phone;
            clients.Update(client);

            // Assert
            Assert.AreEqual(name, clients.Find(id).Name);
            Assert.AreEqual(phone, clients.Find(id).Phone);
        }

        [TestMethod]
        public void DeleteClient()
        {
            // Arrange
            int id = 8;
            var clients = RepositoryObjectMother.CreateClientRepository();
            var client = clients.Find(id);

            // Act
            clients.Delete(client);

            // Assert
            Assert.IsNull(clients.Find(id));
        }


    }
}
