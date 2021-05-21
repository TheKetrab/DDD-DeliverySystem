using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;

namespace Delivery.Infrastructure.Repositories.MsSql
{
    public class MsSqlConnector
    {
        private static MsSqlConnector _instance;
        private static object _lock = new object();

        private SqlConnection conn;
        private readonly string connectionString =
            "Data Source=LAPTOP-BARTEK;Initial Catalog=AbcDeliverySystem;Integrated Security=True";


        public static MsSqlConnector Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock(_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MsSqlConnector();
                            _instance.conn = new SqlConnection(_instance.connectionString);
                        }
                    }
                }

                return _instance;
            }
        }

        public SqlConnection Connection 
        {
            get 
            {
                return _instance.conn;
            }
        }

    }
}
