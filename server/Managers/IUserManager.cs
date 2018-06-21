using System.Threading.Tasks;
using server.Models.DataModels;

namespace server.Managers
{
    public interface IUserManager
    {
        Task<bool> AddNewUser(UserDataModel model);
    }
}