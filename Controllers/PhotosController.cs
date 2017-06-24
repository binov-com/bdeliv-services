using System;
using System.Collections.Generic;
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
using Microsoft.Extensions.Options;

namespace bdeliv_services.Controllers
{
    [Route("/api/products/{productId}/photos")]
    public class PhotosController : Controller
    {
        private readonly IHostingEnvironment host;
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        private readonly PhotoSettings photoSettings;
        private readonly IPhotoRepository photoRepository;
        private readonly IPhotoService photoService;

        public PhotosController(IHostingEnvironment host, IProductRepository productRepository,
            IPhotoRepository photoRepository, IMapper mapper, IOptionsSnapshot<PhotoSettings> options, IPhotoService photoService)
        {
            this.photoService = photoService;
            this.photoRepository = photoRepository;
            this.photoSettings = options.Value;
            this.mapper = mapper;
            this.productRepository = productRepository;
            this.host = host;
        }

        [HttpGet]
        public async Task<IEnumerable<PhotoResource>> GetPhotos(int productId)
        {
            var photos = await photoRepository.GetPhotos(productId);

            return mapper.Map<IEnumerable<Photo>, IEnumerable<PhotoResource>>(photos);
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(int productId, IFormFile file)
        {
            var product = await productRepository.GetProduct(productId);
            if (product == null)
                return NotFound();

            if (file == null)
                return BadRequest("Null file.");

            if (file.Length == 0)
                return BadRequest("Empty file.");

            if (file.Length > photoSettings.MaxBytes)
                return BadRequest("Maximum file size exceeded.");

            if (!photoSettings.IsSupported(file.FileName))
                return BadRequest("Invalid file type.");

            var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads"); // .../wwwroot/uploads/

            var photo = await photoService.uploadPhotoAsync(product, file, uploadsFolderPath);

            return Ok(mapper.Map<Photo, PhotoResource>(photo));

        }
    }
}