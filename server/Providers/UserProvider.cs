using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using server.Models.DataModels;
using System;

namespace server.Providers
{   
    public class UserProvider : IUserProvider
    {
        private readonly IConfiguration configuration; 

        public UserProvider(IConfiguration config)
        {
            this.configuration = config;
        }

        public async Task<IEnumerable<UserDataModel>> GetAllUsers()
        {
            using(var connection = new MySqlConnection(this.configuration.GetConnectionString("Default")))
            {
                await connection.OpenAsync();
                return connection.Query<UserDataModel>("GetAllUsers", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<string> GetUserHashedPassword(string email)
        {
            using(var connection = new MySqlConnection(this.configuration.GetConnectionString("Default")))
            {
                await connection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("EmailParam", email, DbType.String);
                var password = connection.QueryFirstOrDefault<string>("GetUserHashedPassword", parameters, commandType: CommandType.StoredProcedure);
                return password ?? String.Empty;
            }
        }
    }
}