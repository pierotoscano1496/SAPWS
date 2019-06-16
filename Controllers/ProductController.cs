using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SAPWS.Context;
using SAPWS.Models;

namespace SAPWS.Controllers
{

    [Route("api/[controller]/[action]")]
    public class ProductController : Controller
    {
        private ProductContext objContext;
        private readonly IConfigurationRoot _configuration;

        public ProductController(IConfigurationRoot configuration)
        {
            this._configuration = configuration;
            string mysqlConnStr = _configuration.GetConnectionString("DefaultConnection");
            objContext = new ProductContext(mysqlConnStr);
        }

        [HttpGet]
        public IActionResult GetListProductsByCustomer(int customerId)
        {
            try
            {
                List<Product> listProducts = objContext.GetListProductsByCustomer(customerId);
                return Ok(listProducts);
            }
            catch
            {
                return BadRequest("Error de ejecución");
            }
        }
    }
}