using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Domain.Model.Orders
{
    public enum OrderAction
    {
        Create,
        Pay,
        Cancel,
        Delete,
        Deliver
    }
}
