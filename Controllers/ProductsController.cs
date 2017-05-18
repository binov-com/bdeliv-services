using System;
using System.Threading.Tasks;
using AutoMapper;
using bdeliv_services.Controllers.Resources;
using bdeliv_services.Models;
using bdeliv_services.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace bdeliv_services.Controllers
{
    [Route("/api/products")]
    public class ProductsController : Controller
    {
        private readonly IMapper mapper;
        private readonly BdelivDbContext context;
        public ProductsController(IMapper mapper, BdelivDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductResource productResource)
        {
            var product = mapper.Map<ProductResource, Product>(productResource);

            // Defaults Values 
            product.Status = true;
            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = DateTime.Now;

            context.Products.Add(product);
            await context.SaveChangesAsync();

            var result = mapper.Map<Product, ProductResource>(product);

            return Ok(result);
        }
    }
}