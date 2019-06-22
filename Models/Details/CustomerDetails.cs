using System;
using System.Collections.Generic;

namespace SAPWS.Models.Details
{
    public class CustomerDetails
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string CompanyEmail { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public List<Product> ListProducts { get; set; }
        public List<Employee> ListEmployees { get; set; }
    }
}