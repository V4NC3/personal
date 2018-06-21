using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;

namespace server.Providers
{
    public class FeedProvider : IFeedProvider
    {
        private readonly IConfiguration configuration; 

        public FeedProvider(IConfiguration config)
        {
            this.configuration = config;
        }

        public async Task<IEnumerable<dynamic>> GetUserFeeds(int userId)
        {
            using(var connection = new MySqlConnection(this.configuration.GetConnectionString("Default")))
            {
                await connection.OpenAsync();

                var parameters = new DynamicParameters();

                return connection.Query<dynamic>("", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}