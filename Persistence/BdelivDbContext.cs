using bdeliv_services.Models;
using Microsoft.EntityFrameworkCore;

namespace bdeliv_services.Persistence
{
    public class BdelivDbContext : DbContext
    {
        public BdelivDbContext(DbContextOptions<BdelivDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Company> Companies { get; set; }
    }
}