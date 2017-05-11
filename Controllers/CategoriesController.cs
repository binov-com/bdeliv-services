using System.Collections.Generic;
using System.Threading.Tasks;
using bdeliv_services.Models;
using bdeliv_services.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bdeliv_services.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly BdelivDbContext context;
        public CategoriesController(BdelivDbContext context)
        {
            this.context = context;

        }

        [HttpGet("api/categories")]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await context.Categories.Include(c => c.Products).ToListAsync();
        }
    }
}