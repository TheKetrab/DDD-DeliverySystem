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
            SessionProvider p = new SessionProvider();

            addresses = new AddressNH(p);
            clients = new ClientNH(p);
            orders = new OrderNH(p);
            products = new ProductNH(p);
            history = new OrderHistoryNH(p);
        }
    }
}
