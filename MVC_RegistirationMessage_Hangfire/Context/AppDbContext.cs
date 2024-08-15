using Microsoft.EntityFrameworkCore;

namespace MVC_RegistirationMessage_Hangfire.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
