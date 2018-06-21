using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Providers
{
    public interface IFeedProvider
    {
        Task<IEnumerable<dynamic>> GetUserFeeds(int userId);
    }
}