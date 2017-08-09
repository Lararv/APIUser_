using Microsoft.EntityFrameworkCore;

namespace APIUser.Models
{
    public class userContext : DbContext
    {
        public userContext(DbContextOptions<userContext> options)
            : base(options)
        {
        }

        public DbSet<user> userItems { get; set; }

    }
}