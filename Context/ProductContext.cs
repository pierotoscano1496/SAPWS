using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using SAPWS.Models;

namespace SAPWS.Context
{
    public class ProductContext : BaseConnection
    {
        public ProductContext(string connectionString) : base(connectionString)
        {
        }

        public List<Product> GetListProductsByCustomer(int customerId)
        {
            List<Product> listProducts = null;

            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand("select * from product where customer_id=" + customerId, conn);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            /*
                             Customer customer = new Customer
                            {
                                CustomerId = reader.GetInt32("customer_id"),
                                Name = reader.GetString("name"),
                                CompanyEmail = reader.GetString("company_email"),
                                Address = reader.GetString("address"),
                                Phone = reader.GetString("phone"),
                                Password = reader.GetString("password")
                            };

                            listProducts.Add(customer);
                             */

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
            return listProducts;
        }
    }
}