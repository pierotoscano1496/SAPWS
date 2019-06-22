using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using SAPWS.Models;
using SAPWS.Models.Details;

namespace SAPWS.Context
{
    public class ProductContext : BaseConnection
    {
        public ProductContext(string connectionString) : base(connectionString)
        {
        }

        /*
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
                                listProducts = new List<Product>();

                                while (reader.Read())
                                {
                                    Product product = new Product
                                    {
                                        ProductId = reader.GetInt32("product_id"),
                                        SapProduct = reader.GetString("sap_product"),
                                        SapVersion = reader.GetString("sap_version"),
                                        SapSupportPackage = reader.GetString("sap_support_package"),
                                        SapServerOperatingSystem = reader.GetString("sap_server_operating_system"),
                                        SapServerIp = reader.GetString("sap_server_ip"),
                                        DatabaseProduct = reader.GetString("database_product"),
                                        DatabaseVersion = reader.GetString("database_version"),
                                        DatabaseSupportPackage = reader.GetString("database_support_package"),
                                        DatabaseServerOperatingSystem = reader.GetString("database_server_operating_system"),
                                        DatabaseServerIp = reader.GetString("database_server_ip"),
                                        CustomerId = reader.GetInt32("customer_id")
                                    };

                                    listProducts.Add(product);
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
                */

        public CustomerDetails GetListProductsByCustomer(int customerId)
        {
            CustomerDetails customerDetails = new CustomerDetails();

            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    //MySqlCommand commandCustomer = new MySqlCommand(@"SELECT * FROM customer WHERE customer_id=" + customerId, conn);
                    MySqlCommand command = new MySqlCommand(@"SELECT * from product WHERE customer_id=" + customerId, conn);

                    //MySqlDataReader readerCustomer = commandCustomer.ExecuteReader(CommandBehavior.SingleRow);
                    MySqlDataReader reader = command.ExecuteReader();

                    // if (readerCustomer.Read())
                    // {
                    //     customerDetails.Name = readerCustomer.GetString("name");
                    // }

                    customerDetails.Name = "Interbank";

                    if (reader.HasRows)
                    {
                        List<Product> listProducts = new List<Product>();

                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductId = reader.GetInt32("product_id"),
                                SapProduct = reader.GetString("sap_product"),
                                SapVersion = reader.GetString("sap_version"),
                                SapSupportPackage = reader.GetString("sap_support_package"),
                                SapServerOperatingSystem = reader.GetString("sap_server_operating_system"),
                                SapServerIp = reader.GetString("sap_server_ip"),
                                DatabaseProduct = reader.GetString("database_product"),
                                DatabaseVersion = reader.GetString("database_version"),
                                DatabaseSupportPackage = reader.GetString("database_support_package"),
                                DatabaseServerOperatingSystem = reader.GetString("database_server_operating_system"),
                                DatabaseServerIp = reader.GetString("database_server_ip"),
                                CustomerId = reader.GetInt32("customer_id")
                            };

                            listProducts.Add(product);
                        }

                        customerDetails.ListProducts = listProducts;
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
            return customerDetails;
        }
    }
}