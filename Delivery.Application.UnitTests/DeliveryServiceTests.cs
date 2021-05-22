using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Delivery.ObjectMothers;
using Delivery.Generic.Utils;
using Delivery.Domain.Model.Orders;

namespace Delivery.Application.UnitTests
{
    [TestClass]
    public class DeliveryServiceTests
    {
        [TestMethod]
        public void GetClientByEmailTest()
        {
            // Arrange
            var service = ApplicationServicesObjectMother.CreateDeliveryServiceIM();
            var client = ClientObjectMother.CreateUser();
            string mail = "MyMail@abc.xyz";

            // Act
            client.Email = mail;
            service.CreateNewClient(client);
            var c = service.GetClientByEmail(mail);

            // Assert
            Assert.AreEqual(client, c);
        }

        [TestMethod]
        public void VerifyPasswordTest()
        {
            // Arrange
            var service = ApplicationServicesObjectMother.CreateDeliveryServiceIM();
            var client = ClientObjectMother.CreateUser();

            // Act
            service.CreateNewClient(client);
            client.SetPassword("abc");

            // Assert
            Assert.IsTrue(service.VerifyPassword(client, "abc"));
            Assert.IsFalse(service.VerifyPassword(client, "xyz"));
        }

        [TestMethod]
        public void GetClientOrdersTest()
        {
            // Arrange
            var service = ApplicationServicesObjectMother.CreateDeliveryServiceIM();
            var client = ClientObjectMother.CreateUser();

            // Act
            var orders = service.GetClientOrders(client);

            // Assert
            foreach (var o in orders)
                Assert.AreEqual(client, o.Owner);
        }

        [TestMethod]
        public void GetOrderHistoryTest()
        {
            // Arrange
            var service = ApplicationServicesObjectMother.CreateDeliveryServiceIM();
            var order = OrderObjectMother.CreateEmptyOrder();

            // Act
            service.CreateNewOrder(order);
            service.CancelOrder(order);

            // Assert
            var history = service.GetOrderHistory(order).ToList();
            Assert.AreEqual(OrderAction.Create, history[0].Action);
            Assert.AreEqual(OrderAction.Cancel, history[1].Action);
        }

    }
}
