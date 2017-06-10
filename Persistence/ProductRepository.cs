using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using bdeliv_services.Core;
using bdeliv_services.Extensions;
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

        public async Task<IEnumerable<Product>> GetProducts(ProductQuery queryObj) 
        {
            var query = context.Products
                .Include(p => p.Category)
                .Include(p => p.Tags)
                    .ThenInclude(pt => pt.Tag)
                .AsQueryable();
            
            if(queryObj.CategoryId.HasValue)
                query = query.Where(p => p.CategoryId == queryObj.CategoryId.Value); // .Value because CategoryId is Nullable (int?)

            if(queryObj.Name != null && queryObj.Name != "")
                query = query.Where(p => p.Name.Contains(queryObj.Name));

            var columnsMap = new Dictionary<string, Expression<Func<Product, object>>>()
            { 
                ["category"] = p => p.Category.Name,     // columnsMap.Add("category", p => p.Category.Name);
                ["reference"] = p => p.Reference,        // columnsMap.Add("reference", p => p.Reference);
                ["name"] = p => p.Name                   // columnsMap.Add("name", p => p.Name);
            };

            query = query.ApplyOrdering(queryObj, columnsMap);

            query = query.ApplyPaging(queryObj);
            
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