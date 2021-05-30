using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

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
                            _instance.factory = new Configuration().Configure().BuildSessionFactory();
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
    }
}
