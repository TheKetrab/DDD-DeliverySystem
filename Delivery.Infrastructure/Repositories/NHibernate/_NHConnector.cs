using System;
using System.Collections.Generic;
using System.Text;
using Delivery.Infrastructure.Repositories.NHibernate.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;

namespace Delivery.Infrastructure.Repositories.NHibernate
{
    public class NHConnector
    {
        private static NHConnector _instance;
        private static object _lock = new object();
        private ISessionFactory factory;

        public static NHConnector Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new NHConnector();

                            var configuration = _instance.Configure();

                            _instance.factory = configuration.BuildSessionFactory();
                        }
                    }
                }

                return _instance;
            }
        }
        public ISession OpenSession()
        {
            return factory.OpenSession();
        }


        private Configuration Configure()
        {
            var mapper = new ModelMapper();
            mapper.AddMapping(typeof(ClientMapping));
            mapper.AddMapping(typeof(OrderMapping));
            var hbmMappings = mapper.CompileMappingForAllExplicitlyAddedEntities();

            Configuration configuration = new Configuration().Configure();
            configuration.AddMapping(hbmMappings);

            return configuration;
        }
    }
}
