using AutoMapper;
using bdeliv_services.Controllers.Resources;
using bdeliv_services.Models;
using Microsoft.AspNetCore.Mvc;

namespace bdeliv_services.Controllers
{
    [Route("/api/products")]
    public class ProductsController : Controller
    {
        private readonly IMapper mapper;
        public ProductsController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductResource productResource)
        {
            var product = mapper.Map<ProductResource, Product>(productResource);
            
            return Ok(product);
        }
    }
}