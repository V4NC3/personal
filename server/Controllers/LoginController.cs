using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        [HttpPost("token")]
        public IActionResult GetToken()
        {
            var header = Request.Headers["Authorization"]; 
            if (header.ToString().StartsWith("Basic")) 
            {
                var credValue = header.ToString().Substring("Basic ".Length).Trim();
                var clientAndPassenc = Encoding.UTF8.GetString(Convert.FromBase64String(credValue)); //admin:pass
                var clientAndPass = clientAndPassenc.Split(":");
                //check in DB username and pass exist

                if (clientAndPass[0] == "Admin" && clientAndPass[1] == "pass")
                {
                    var claimsdata = new[] { new Claim(ClaimTypes.Name, clientAndPass[0]) };
                    //using secret key
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecretKeyStoredInConfigFile"));
                    var signingCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                    var tokenString = new JwtSecurityToken(
                        issuer: "mysite.com",
                        audience: "mysite.com",
                        expires: DateTime.Now.AddMinutes(1),
                        claims: claimsdata,
                        signingCredentials: signingCred
                    );
                    var tkn = new JwtSecurityTokenHandler().WriteToken(tokenString);
                    return Ok(tkn);
                }
            }
            return BadRequest("Wrong Requested Token");
        }
    }
}