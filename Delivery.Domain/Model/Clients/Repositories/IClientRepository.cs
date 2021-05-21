using System;
using System.Collections.Generic;
using System.Text;

using Delivery.Generic.Interfaces;

namespace Delivery.Domain.Model.Clients.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Client GetClientByEmail(string email);

    }
}
