using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models.DataModels;
using server.Providers;
using server.Services;

namespace server.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : Controller
    {
        // inject password service
        private readonly IPasswordService passwordService;
        private readonly IUserProvider userProvider;

        public LoginController(IPasswordService passwordService, IUserProvider userProvider)
        {
            this.passwordService = passwordService;
            this.userProvider = userProvider;
        }

        [HttpPost]

        public async Task<IActionResult> Login(UserLoginModel model) 
        {
            //null checking
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userHashedPassword = await this.userProvider.GetUserHashedPassword(model.Email);      
            var isValidPassword = this.passwordService.VerifyPassword(userHashedPassword, model.Password);

            if (!isValidPassword)
            {
                return BadRequest("Password is invalid");
            }

            var token = new JwtSecurityToken(
                issuer: "test",
                expires: DateTime.Now.AddDays(1)
            );
            return Ok("Logged In");
        }
    }
}