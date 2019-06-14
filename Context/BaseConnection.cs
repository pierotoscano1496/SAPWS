using System;
using MySql.Data.MySqlClient;

namespace SAPWS.Context
{
    public class BaseConnection
    {
        protected string ConnectionString { get; set; }

        public BaseConnection(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(this.ConnectionString);
        }
    }
}