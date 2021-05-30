using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Clients.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delivery.Infrastructure.Repositories.NHibernate
{
    public class ClientNH : BaseImplNH<Client>, IClientRepository
    {
        public override string Table => "Client";

        public Client GetClientByEmail(string email)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
