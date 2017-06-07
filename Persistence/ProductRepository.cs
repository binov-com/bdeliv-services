using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bdeliv_services.Core;
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

        public async Task<IEnumerable<Product>> GetProducts(Filter filter) 
        {
            var query = context.Products
                .Include(p => p.Category)
                .Include(p => p.Tags)
                    .ThenInclude(pt => pt.Tag)
                .AsQueryable();
            
            if(filter.CategoryId.HasValue)
                query = query.Where(p => p.CategoryId == filter.CategoryId.Value); // .Value because CategoryId is Nullable (int?)

            return await query.ToListAsync();
        }

        public async Task<Product> GetProduct(int id, bool includeRelated = false)
        {
            if (!includeRelated)
                return await context.Products.FindAsync(id);

            return await context.Products
                .Include(p => p.Tags)
                    .ThenInclude(pt => pt.Tag)
                .Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> GetProductWithCategory(int id) 
        {
            return await context.Products
                .Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public void Add(Product product) 
        {
            context.Products.Add(product);
        }

        public void Remove(Product product)
        {
            context.Products.Remove(product);
        }
    }
}