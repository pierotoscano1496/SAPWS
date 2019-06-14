using System;
using System.Data;
using MySql.Data.MySqlClient;
using SAPWS.Models;

namespace SAPWS.Context
{
    public class LoginContext : BaseConnection
    {
        public LoginContext(string connectionString) : base(connectionString)
        {
        }

        public Customer Login(string companyEmail, string password)
        {
            Customer customerLogged = null;

            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand("select * from customer where company_email='" + companyEmail + "' and password='" + password + "'", conn);
                    MySqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer
                            {
                                CustomerId = reader.GetInt32("customer_id"),
                                Name = reader.GetString("name"),
                                CompanyEmail = reader.GetString("company_email"),
                                Address = reader.GetString("address"),
                                Phone = reader.GetString("phone"),
                                Password = reader.GetString("password")
                            };

                            customerLogged = customer;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return customerLogged;
        }
    }
}