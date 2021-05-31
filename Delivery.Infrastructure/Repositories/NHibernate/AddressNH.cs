using Delivery.Domain.Model.Addresses;
using Delivery.Domain.Model.Addresses.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;



namespace Delivery.Infrastructure.Repositories.NHibernate
{
    public class AddressNH : BaseImplNH<Address>, IAddressRepository
    {
        public override string Table => "Address";

        public AddressNH(SessionProvider p) : base(p) { }
    }
}
