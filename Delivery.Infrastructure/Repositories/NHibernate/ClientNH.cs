using Delivery.Domain.Model.Clients;
using Delivery.Domain.Model.Clients.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate.Linq;

namespace Delivery.Infrastructure.Repositories.NHibernate
{
    public class ClientNH : BaseImplNH<Client>, IClientRepository
    {
        public override string Table => "Client";

        public ClientNH(SessionProvider p) : base(p) { }

        public Client GetClientByEmail(string email)
        {
            using (var session = OpenSession())
            {
                return session.Query<Client>()
                    .Where(e => e.Email == email).Single();
            }

        }
    }
}
