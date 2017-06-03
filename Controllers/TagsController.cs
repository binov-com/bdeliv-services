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
    public class TagsController : Controller
    {
        private readonly BdelivDbContext context;
        private readonly IMapper mapper;

        public TagsController(BdelivDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("api/tags")]
        public async Task<IEnumerable<KeyValuePairResource>> GetCategories()
        {
            var tags = await context.Tags.ToListAsync();
            
            return mapper.Map<List<Tag>, List<KeyValuePairResource>>(tags);
        }

    }
}