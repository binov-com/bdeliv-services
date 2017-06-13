using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bdeliv_services.Controllers.Resources;
using bdeliv_services.Core;
using bdeliv_services.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bdeliv_services.Controllers
{
    [Route("/api/products/{productId}/photos")]
    public class PhotosController : Controller
    {
        private readonly int MAX_BYTES = 10 * 1024 * 1024;
        private readonly string[] ACCEPTED_FILE_TYPES = new[] { ".png", ".jpg", ".jpeg" };

        private readonly IHostingEnvironment host;
        private readonly IProductRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public PhotosController(IHostingEnvironment host, IProductRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.host = host;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(int productId, IFormFile file)
        {
            var product = await repository.GetProduct(productId);            
            if (product == null) 
                return NotFound();

            if(file == null) 
                return BadRequest("Null file.");
            
            if(file.Length == 0) 
                return BadRequest("Empty file.");
            
            if(file.Length > MAX_BYTES) 
                return BadRequest("Maximum file size exceeded.");
            
            if(!ACCEPTED_FILE_TYPES.Any(s => s == Path.GetExtension(file.FileName))) 
                return BadRequest("Invalid file type.");

            var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads"); // .../wwwroot/uploads/
            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var photo = new Photo { FileName = fileName };
            product.Photos.Add(photo);
            await unitOfWork.CompleteAsync();
            
            return Ok(mapper.Map<Photo, PhotoResource>(photo));

        }
    }
}