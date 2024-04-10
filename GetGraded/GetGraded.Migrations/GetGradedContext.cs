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
    }
}
