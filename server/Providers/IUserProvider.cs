using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models.DataModels;

namespace server.Providers
{
    public interface IUserProvider
    {
        Task<IEnumerable<UserDataModel>> GetAllUsers();
    }
}