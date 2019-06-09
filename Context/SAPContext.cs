using System;
using MySql.Data.MySqlClient;

namespace SAPWS.Context
{
    public class SAPContext
    {
        public string ConnectionString { get; set; }

        public SAPContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}