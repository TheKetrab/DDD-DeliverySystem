using Delivery.Domain.Model.Addresses.Repositories;
using Delivery.Infrastructure.Repositories.NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.ObjectMothers
{
    public class NHRepositoryObjectMother
    {
        private static NHRepositoryObjectMother _instance;
        private static object _lock = new object();
        private SessionProvider _provider;

        public static NHRepositoryObjectMother Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            // create new database using main connection
                            NHConnector.Instance.Provider.ExecuteSQLFile("../SqlScripts/CreateTestDatabase.sql");

                            // create connection with test database and run scripts
                            _instance._provider = new SessionProvider(true);
                            _instance._provider.ExecuteSQLFile("../SqlScripts/CreateTables.sql");
                            _instance._provider.ExecuteSQLFile("../SqlScripts/RandomData.sql");
                        }
                    }
                }

                return _instance;
            }
        }

        ~NHRepositoryObjectMother()
        {
            NHConnector.Instance.Provider.ExecuteSQLFile("../SqlScripts/DeleteTestDatabase.sql");
        }

        public AddressNH CreateAddressNHRepository()
        {
            return new AddressNH(_provider);
        }

        public ClientNH CreateClientNHRepository()
        {
            return new ClientNH(_provider);
        }
        public OrderNH CreateOrderNHRepository()
        {
            return new OrderNH(_provider);
        }
        public ProductNH CreateProductNHRepository()
        {
            return new ProductNH(_provider);
        }

        public OrderHistoryNH CreateOrderHistoryNHRepository()
        {
            return new OrderHistoryNH(_provider);
        }

    }
}
