using Delivery.Infrastructure.Repositories.NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Application
{
    public class NHibernateDeliveryProvider : DeliveryProvider
    {
        public NHibernateDeliveryProvider()
        {
            addresses = new AddressNH();
            clients = new ClientNH();
            orders = new OrderNH();
            products = new ProductNH();
            history = new OrderHistoryNH();
        }
    }
}
