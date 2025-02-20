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
    public class ProductController : Controller
    {
        private List<Product> listProducts;
        private ProductContext objContext;
        private readonly IConfigurationRoot _configuration;

        public ProductController(IConfigurationRoot configuration)
        {
            this._configuration = configuration;
            string mysqlConnStr = _configuration.GetConnectionString("DefaultConnection");
            objContext = new ProductContext(mysqlConnStr);
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IActionResult GetListProductsByCustomer(int customerId)
        {
            try
            {
                //List<Product> listProducts = objContext.GetListProductsByCustomer(customerId);
                CustomerDetails CustomerDetails = objContext.GetListProductsByCustomer(customerId);
                return Ok(CustomerDetails);
            }
            catch
            {
                return BadRequest("Error de ejecución");
            }
        }
    }
}