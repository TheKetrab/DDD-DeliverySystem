using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Infrastructure.Repositories.NHibernate
{
    public class NHConnector
    {
        private static NHConnector _instance;
        private static object _lock = new object();

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
                            _instance.Provider = new SessionProvider();
                        }
                    }
                }

                return _instance;
            }
        }

        public SessionProvider Provider { get; private set; }
    }
}
