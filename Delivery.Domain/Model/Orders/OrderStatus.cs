using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Domain.Model.Orders
{
    public enum Status
    {
        Inactive,
        WaitingForPayment,
        Paid,
        Sent,
        Delivered,
        Canceled
    }
}
