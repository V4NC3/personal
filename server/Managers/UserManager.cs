using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;

namespace server.Managers
{
    public class UserManager
    {
        private readonly IConfiguration configuration;

        public UserManager(IConfiguration config)
        {
            this.configuration = config;
        }

        public async Task<bool> GetNewUser()
        {
            using(var connection = new MySqlConnection(this.configuration.GetConnectionString("default")))
            {
                await connection.OpenAsync();
                connection.Execute("", commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}