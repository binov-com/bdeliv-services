using System.Threading.Tasks;
using bdeliv_services.Models;
using Microsoft.EntityFrameworkCore;

namespace bdeliv_services.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly BdelivDbContext context;
        public ProductRepository(BdelivDbContext context)
        {
            this.context = context;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await context.Products
                .Include(t => t.Tags)
                    .ThenInclude(pt => pt.Tag)
                .Include(t => t.Category)
                .SingleOrDefaultAsync(t => t.Id == id);
        }
    }
}