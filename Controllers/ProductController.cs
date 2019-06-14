using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SAPWS.Controllers{

    [Route("api/[controller]/[action]")]
    public class ProductController:Controller{
        private ProductContext objContext;
        private readonly IConfigurationRoot _configuration;

        public ProductController(IConfigurationRoot configuration){
            this._configuration=configuration;
            string mysqlConnStr = _configuration.GetConnectionString("DefaultConnection");
            objContext = new ProductContext(mysqlConnStr);
        }
    }
}