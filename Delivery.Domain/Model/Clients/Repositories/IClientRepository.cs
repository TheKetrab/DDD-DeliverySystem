using System;
using System.Collections.Generic;
using System.Text;

using Delivery.Generic.Interfaces;

namespace Delivery.Domain.Model.Clients.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        int Count { get; }
        Client GetClientByEmail(string email);
        void SetRole(Client client, Role role);

        void SetPassword(Client client, string password);
    }
}
