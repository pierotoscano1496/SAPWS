using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SAPWS.Models;
using SAPWS.Context;

namespace SAPWS.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LoginController : Controller
    {
        private LoginContext objContext;
        private readonly IConfigurationRoot _configuration;

        public LoginController(IConfigurationRoot configuration)
        {
            _configuration = configuration;
            string mysqlConnStr = _configuration.GetConnectionString("DefaultConnection");
            objContext = new LoginContext(mysqlConnStr);
        }

        [HttpPost]
        public IActionResult Login([FromBody]User user)
        {
            try
            {
                Customer customerLogged = objContext.Login(user.Email, user.Password);
                return Ok(customerLogged);
            }
            catch
            {
                return BadRequest("Correo o contraseña incorrecta");
            }
        }
    }
}