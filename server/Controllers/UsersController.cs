using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Managers;
using server.Models.DataModels;
using server.Providers;
using server.Services;

namespace server.Controllers {
    [Route ("api/user")]
    [ApiController]
    public class UsersController : Controller {

        //Providers
        private readonly IUserProvider userProvider;

        //Managers
        private readonly IUserManager userManager;

        //Services
        private readonly IPasswordService passwordService;

        public UsersController (
                IUserProvider userProvider,
                IPasswordService passwordService,
                IUserManager userManager
            ) 
        {
            this.userProvider = userProvider;
            this.passwordService = passwordService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers() 
        {
            var data = await this.userProvider.GetAllUsers ();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(UserDataModel model) 
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try 
            {
                model.Password = this.passwordService.HashPassword(model.Password);
                await this.userManager.AddNewUser(model);
                return Ok();
            }
            catch(Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}