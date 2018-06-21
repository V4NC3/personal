using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;
using server.Models.DataModels;

namespace server.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IConfiguration configuration;

        public UserManager(IConfiguration config)
        {
            this.configuration = config;
        }

        public async Task<bool> AddNewUser(UserDataModel model)
        {
            using(var connection = new MySqlConnection(this.configuration.GetConnectionString("default")))
            {
                try
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("FirstNameParam", model.FirstName, DbType.String);
                    parameters.Add("LastNameParam", model.LastName, DbType.String);
                    parameters.Add("AgeParam", model.Age, DbType.Int32);
                    parameters.Add("EmailParam", model.FirstName, DbType.String);
                    parameters.Add("PasswordParam", model.Password, DbType.String);

                    connection.Execute("InsertNewUser", parameters, commandType: CommandType.StoredProcedure);
                    return true;
                }
                catch(MySqlException err)
                {
                    throw err;
                }
            }
        }
    }
}