using bdeliv_services.Models;
using Microsoft.EntityFrameworkCore;

namespace bdeliv_services.Persistence
{
    public class BdelivDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public BdelivDbContext(DbContextOptions<BdelivDbContext> options) : base(options)
        {

        }
        
    }
}