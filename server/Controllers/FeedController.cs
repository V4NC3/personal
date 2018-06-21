using Microsoft.AspNetCore.Mvc;
using server.Providers;

namespace server.Controllers
{
    [Route ("api/feed")]
    [ApiController]
    public class FeedController : Controller
    {
        //Providers
        private readonly IFeedProvider feedProvider;

        public FeedController(
                IFeedProvider feedProvider
            )
        {
            this.feedProvider = feedProvider;
        }
    }
}