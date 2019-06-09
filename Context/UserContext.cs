using System;
using MySql.Data.MySqlClient;

namespace SAPWS.Context
{
    public class UserContext : SAPContext
    {
        public UserContext(string connectionString) : base(connectionString)
        {
        }

        public bool Login(string companyEmail, string password)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM customer WHERE company_email='" + companyEmail + "' AND password='" + password + "'");

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                }
                return false;
            }
        }
    }
}