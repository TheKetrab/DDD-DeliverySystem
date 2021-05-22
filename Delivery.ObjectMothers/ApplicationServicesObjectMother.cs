using System;
using System.Collections.Generic;
using System.Text;

using Delivery.Application;

namespace Delivery.ObjectMothers
{
    public static class ApplicationServicesObjectMother
    {
        public IDeliveryService CreateDeliveryServiceIM()
        {
            return new DeliveryService()
            {
                
            };
        }

        public IDeliveryService CreateDeliveryServiceMsSQL()
        {
            return new DeliveryService();
        }


    }
}
