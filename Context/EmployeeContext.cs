using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using SAPWS.Models;
using SAPWS.Models.Details;

namespace SAPWS.Context
{
    public class EmployeeContext : BaseConnection
    {
        public EmployeeContext(string connectionString) : base(connectionString)
        {
        }

        public CustomerDetails GetListEmployeesByCustomer(int customerId)
        {
            CustomerDetails customerDetails = new CustomerDetails();

            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    //MySqlCommand commandCustomer = new MySqlCommand(@"SELECT * FROM customer WHERE customer_id=" + customerId, conn);
                    MySqlCommand command = new MySqlCommand(@"SELECT * from employee WHERE customer_id=" + customerId, conn);

                    //MySqlDataReader readerCustomer = commandCustomer.ExecuteReader(CommandBehavior.SingleRow);
                    MySqlDataReader reader = command.ExecuteReader();

                    // if (readerCustomer.Read())
                    // {
                    //     customerDetails.Name = readerCustomer.GetString("name");
                    // }

                    customerDetails.Name = "Interbank";

                    if (reader.HasRows)
                    {
                        List<Employee> listEmployees = new List<Employee>();

                        while (reader.Read())
                        {
                            /*
                            Employee employee = new Employee
                            {
                                EmployeeId = reader.GetInt32("employee_id"),
                                Name = reader.GetString("name"),
                                Surname = reader.GetString("surname"),
                                Dni = reader.GetString("dni"),
                                NumberAccount = reader.GetInt32("number_account"),
                                Amount = reader.GetDouble("amount"),
                                Email = reader.GetString("email"),
                                CustomerId = reader.GetInt32("customer_id")
                            };
                            */
                            Employee employee = new Employee();
                            employee.EmployeeId = reader.GetInt32("employee_id");
                            employee.Name = reader.GetString("name");
                            employee.Surname = reader.GetString("surname");
                            employee.Dni = reader.GetString("dni");
                            employee.NumberAccount = reader.GetInt32("number_account");
                            employee.Amount = reader.GetDecimal("amount");
                            employee.Email = reader.GetString("email");
                            employee.CustomerId = reader.GetInt32("customer_id");

                            listEmployees.Add(employee);
                        }

                        customerDetails.ListEmployees = listEmployees;
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