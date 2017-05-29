using System;
using System.Threading.Tasks;
using AutoMapper;
using bdeliv_services.Controllers.Resources;
using bdeliv_services.Models;
using bdeliv_services.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bdeliv_services.Controllers
{
    [Route("/api/products")]
    public class ProductsController : Controller
    {
        private readonly IMapper mapper;
        private readonly BdelivDbContext context;
        private readonly IProductRepository repository;
        public ProductsController(IMapper mapper, BdelivDbContext context, IProductRepository repository)
        {
            this.repository = repository;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] SaveProductResource productResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // var category = await context.Categories.FindAsync(productResource.CategoryId);
            // if(category == null)
            // {
            //     ModelState.AddModelError("CategoryId","Invalid categoryId.");
            //     return BadRequest(ModelState);
            // }

            var product = mapper.Map<SaveProductResource, Product>(productResource);

            // Defaults Values 
            product.Status = true;
            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = DateTime.Now;

            repository.Add(product);
            await context.SaveChangesAsync();

            product = await repository.GetProduct(product.Id);

            var result = mapper.Map<Product, ProductResource>(product);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] SaveProductResource productResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await context.Products
                .Include(p => p.Tags)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound();

            mapper.Map<SaveProductResource, Product>(productResource, product);

            product.UpdatedAt = DateTime.Now;

            await context.SaveChangesAsync();

            product = await repository.GetProduct(product.Id);

            var result = mapper.Map<Product, ProductResource>(product);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await repository.GetProduct(id);

            if (product == null)
                return NotFound();

            repository.Remove(product);
            await context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await repository.GetProduct(id, includeRelated: true);

            if (product == null)
                return NotFound();

            var productResource = mapper.Map<Product, ProductResource>(product);

            return Ok(productResource);
        }
    }
}