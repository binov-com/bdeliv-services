using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using bdeliv_services.Controllers.Resources;
using bdeliv_services.Models;
using bdeliv_services.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bdeliv_services.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly BdelivDbContext context;
        private readonly IMapper mapper;
        public CategoriesController(BdelivDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpGet("api/categories")]
        public async Task<IEnumerable<CategoryResource>> GetCategories()
        {
            var categories = await context.Categories.Include(c => c.Products).ToListAsync();
            
            return mapper.Map<List<Category>, List<CategoryResource>>(categories);
        }
    }
}