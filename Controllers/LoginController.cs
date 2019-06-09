using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SAPWS.Models;

namespace SAPWS.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LoginController : Controller
    {
        [HttpPost]
        public IActionResult Login([FromBody]string email, [FromBody]string password)
        {
            if (email == "" && password == "")
            {
                return Ok("Éxito al ingresar");
            }
            else
            {
                return BadRequest("Error de autenticación");
            }
        }
    }
}