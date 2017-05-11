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
    public class UsersController
    {
        private readonly BdelivDbContext context;
        private readonly IMapper mapper;
        public UsersController(BdelivDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpGet("api/users")]
        public async Task<IEnumerable<UserResource>> GetCategories()
        {
            var users = await context.Users.ToListAsync();
            
            return mapper.Map<List<User>, List<UserResource>>(users);
        }
    }
}