using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models.DataModels;
using server.Providers;

namespace server.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserProvider userProvider;

        public UsersController(IUserProvider userProvider)
        {
            this.userProvider = userProvider;
        }
        public async Task<ActionResult<IEnumerable<UserDataModel>>> GetAllUsers()
        {
            var data = await this.userProvider.GetAllUsers();
            return data.ToList();
        }
    }
}