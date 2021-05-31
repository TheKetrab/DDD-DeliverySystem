using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Delivery.Infrastructure.Repositories.NHibernate.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;

namespace Delivery.Infrastructure.Repositories.NHibernate
{
    // session provider to opakowanie dla fabryki połączeń do bazy
    // opakowanie -> odpala KONKRETNĄ konfigurację (np. inne połączenie z bazą testową)
    public class SessionProvider
    {        
        private ISessionFactory factory;

        public SessionProvider(bool testDB = false)
        {
            var configuration = Configure(testDB);
            factory = configuration.BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return factory.OpenSession();
        }

        private static Configuration Configure(bool testDB = false)
        {
            var mapper = new ModelMapper();
            mapper.AddMapping(typeof(ClientMapping));
            mapper.AddMapping(typeof(OrderMapping));
            var hbmMappings = mapper.CompileMappingForAllExplicitlyAddedEntities();

            Configuration configuration = new Configuration().Configure();
            configuration.AddMapping(hbmMappings);

            // if test db -> connect to test database
            if (testDB)
            {
                configuration.SetProperty("connection.connection_string",
                    "Data Source=LAPTOP-BARTEK;Initial Catalog=AbcDeliveryTest;Integrated Security=True");
            }

            return configuration;
        }

        public void ExecuteSQLFile(string sqlFilePath)
        {
            string sqlScript;

            using (FileStream fs = File.OpenRead(sqlFilePath))
            {
                var reader = new StreamReader(fs);
                sqlScript = reader.ReadToEnd();
            }

            var regex = new Regex("^GO", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string[] lines = regex.Split(sqlScript);

            using (var session = OpenSession())
            {
                try
                {
                    foreach (string line in lines)
                    {
                        IQuery query = session.CreateSQLQuery(line);
                        query.ExecuteUpdate();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }
}
