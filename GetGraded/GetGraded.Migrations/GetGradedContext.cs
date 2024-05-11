using GetGraded.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GetGraded.Migrations
{
    public class GetGradedContext : IdentityDbContext<IdentityUser>
    {
        public GetGradedContext(DbContextOptions<GetGradedContext> options)
            : base(options)
        {

        }
        public DbSet<TestSave> Service { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<UserLoginDetails> UserLoginDetails { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }

}
