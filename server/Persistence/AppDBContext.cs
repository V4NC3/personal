using Microsoft.EntityFrameworkCore;

namespace server.Persistence
{
    public class AppDBContext : DbContext
    {
        //define table schema here
        public AppDBContext(DbContextOptions<AppDBContext> options) : base (options) {}
    }
}