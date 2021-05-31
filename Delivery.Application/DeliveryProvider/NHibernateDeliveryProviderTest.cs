using Delivery.Infrastructure.Repositories.NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Application
{
    public class NHibernateDeliveryProviderTest : NHibernateDeliveryProvider
    {
        SessionProvider p;

        public NHibernateDeliveryProviderTest()
        {
            // create new database using main connection
            //NHConnector.Instance.Provider.ExecuteSQLFile("../SqlScripts/CreateTestDatabase.sql");

            // create connection with test database and run scripts
            p = new SessionProvider(true);
            p.ExecuteSQLFile("../SqlScripts/CreateTables.sql");
            p.ExecuteSQLFile("../SqlScripts/RandomData.sql");

            addresses = new AddressNH(p);
            clients = new ClientNH(p);
            orders = new OrderNH(p);
            products = new ProductNH(p);
            history = new OrderHistoryNH(p);
        }

        //~NHibernateDeliveryProviderTest()
        //{
        //    //p.ExecuteSQLFile("../SqlScripts/DeleteTestDatabase.sql");            
        //    //NHConnector.Instance.Provider.ExecuteSQLFile("../SqlScripts/DeleteTestDatabase.sql");            
        //}

        
    }
}
