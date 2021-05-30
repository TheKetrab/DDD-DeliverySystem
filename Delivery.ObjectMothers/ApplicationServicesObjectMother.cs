using System;
using System.Collections.Generic;
using System.Text;

using Delivery.Application;

namespace Delivery.ObjectMothers
{
    public static class ApplicationServicesObjectMother
    {
        public static DeliveryService CreateDeliveryServiceIM()
        {
            return new DeliveryService(new IMDeliveryProvider());
        }

        public static DeliveryService CreateDeliveryServiceMsSQLTest()
        {
            return new DeliveryService(new MsSqlDeliveryProviderTest());
        }

        public static DeliveryService CreateDeliveryServiceIMEmpty()
        {
            return new DeliveryService(new IMDeliveryProviderEmpty());
        }

    }
}
