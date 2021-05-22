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

        public static DeliveryService CreateDeliveryServiceMsSQL()
        {
            return new DeliveryService(new MsSqlDeliveryProvider());
        }

        public static DeliveryService CreateDeliveryServiceIMEmpty()
        {
            return new DeliveryService(new IMDeliveryProviderEmpty());
        }

    }
}
