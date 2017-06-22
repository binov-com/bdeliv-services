using System;
using System.Threading.Tasks;
using AutoMapper;
using bdeliv_services.Controllers.Resources;
using bdeliv_services.Models;
using bdeliv_services.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace bdeliv_services.Controllers
{
    [Route("/api/products")]
    public class ProductsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProductRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public ProductsController(IMapper mapper, IUnitOfWork unitOfWork, IProductRepository repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        [Authorize(Policies.RequireAdminRole)]
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
            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = DateTime.Now;

            repository.Add(product);
            await unitOfWork.CompleteAsync();

            product = await repository.GetProduct(product.Id, includeRelated: true);

            var result = mapper.Map<Product, ProductResource>(product);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] SaveProductResource productResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await repository.GetProduct(id, includeRelated: true);

            if (product == null)
                return NotFound();

            mapper.Map<SaveProductResource, Product>(productResource, product);

            product.UpdatedAt = DateTime.Now;

            await unitOfWork.CompleteAsync();

            product = await repository.GetProduct(product.Id, includeRelated: true);
            var result = mapper.Map<Product, ProductResource>(product);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await repository.GetProduct(id);

            if (product == null)
                return NotFound();

            repository.Remove(product);
            await unitOfWork.CompleteAsync();

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

        [HttpGet]
        public async Task<QueryResultResource<ProductResource>> GetProducts(ProductQueryResource filterResource) 
        {
            var filter = mapper.Map<ProductQueryResource, ProductQuery>(filterResource);

            var queryResult = await repository.GetProducts(filter);

            return mapper.Map<QueryResult<Product>, QueryResultResource<ProductResource>>(queryResult);
        }
    }
}