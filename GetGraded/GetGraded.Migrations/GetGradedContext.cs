using GetGraded.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace GetGraded.Migrations
{
    public class GetGradedContext : DbContext
    {
        public GetGradedContext(DbContextOptions<GetGradedContext> options)
            : base(options)
        {

        }
        public DbSet<TestSave> Service { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<UserLoginDetails> UserLoginDetails { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
