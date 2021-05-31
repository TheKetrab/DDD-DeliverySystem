using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Type;
using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Orders;

namespace Delivery.Infrastructure.Repositories.NHibernate
{
    public class RoleType : EnumStringType<Role>
    {
        public static string GetDescription(Role status)
        {
            switch (status)
            {
                case Role.Admin: return "Admin";
                case Role.Moderator: return "Moderator";
                case Role.User: return "User";
                case Role.PremiumUser: return "PremiumUser";
                default: return string.Empty;
            }
        }
    }

    public class OrderStatusType : EnumStringType<Status>
    {
        public static string GetDescription(Status status)
        {
            switch (status)
            {
                case Status.Inactive: return "Inactive";
                case Status.WaitingForPayment: return "WaitingForPayment";
                case Status.Paid: return "Paid";
                case Status.Sent: return "Sent";
                case Status.Delivered: return "Delivered";
                case Status.Canceled: return "Canceled";
                default: return string.Empty;
            }
        }
    }
}
