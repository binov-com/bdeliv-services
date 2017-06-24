using System;
using System.IO;
using System.Threading.Tasks;
using bdeliv_services.Models;
using bdeliv_services.Persistence;
using Microsoft.AspNetCore.Http;

namespace bdeliv_services.Core
{
    public class PhotoService : IPhotoService
    {
        private readonly IUnitOfWork unitOfWork;
        public PhotoService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Photo> uploadPhotoAsync(Product product, IFormFile file, string uploadsFolderPath)
        {
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

            return photo;
        }
    }
}