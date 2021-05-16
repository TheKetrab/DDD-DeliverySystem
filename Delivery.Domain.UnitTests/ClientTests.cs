using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Delivery.ObjectMothers;

namespace Delivery.Domain.UnitTests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void ChangeClientsPassword()
        {
            // Arrange
            var c = ClientObjectMother.CreateRandomUser();

            // Act

            // Assert
        }
    }
}
