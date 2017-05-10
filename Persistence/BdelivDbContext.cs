using Microsoft.EntityFrameworkCore;

namespace bdeliv_services.Persistence
{
    public class BdelivDbContext : DbContext
    {
        public BdelivDbContext(DbContextOptions<BdelivDbContext> options) : base(options)
        {

        }
    }
}