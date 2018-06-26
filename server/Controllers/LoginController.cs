using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using server.Models.DataModels;

namespace server.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : Controller
    {
        [HttpPost]

        public IActionResult Login(UserLoginModel model) 
        {
            var token = new JwtSecurityToken(
                issuer: "test",
                expires: DateTime.Now.AddDays(1)
            );

            return Ok(token);
        }
    }
}