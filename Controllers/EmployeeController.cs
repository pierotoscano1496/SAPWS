using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using SAPWS.Context;
using SAPWS.Models;
using SAPWS.Models.Details;

namespace SAPWS.Controllers
{

    [Route("api/[controller]/[action]")]
    public class EmployeeController : Controller
    {
        private List<Product> listProducts;
        private EmployeeContext objContext;
        private readonly IConfigurationRoot _configuration;

        public EmployeeController(IConfigurationRoot configuration)
        {
            this._configuration = configuration;
            string mysqlConnStr = _configuration.GetConnectionString("DefaultConnection");
            objContext = new EmployeeContext(mysqlConnStr);
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IActionResult GetListEmployeesByCustomer(int customerId)
        {
            try
            {
                //List<Product> listProducts = objContext.GetListProductsByCustomer(customerId);
                CustomerDetails customerDetails = objContext.GetListEmployeesByCustomer(customerId);
                return Ok(customerDetails);
            }
            catch
            {
                return BadRequest("Error de ejecución");
            }
        }


    }
}