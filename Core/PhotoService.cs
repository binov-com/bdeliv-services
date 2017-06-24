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
        private readonly IPhotoStorage photoStorage;
        public PhotoService(IUnitOfWork unitOfWork, IPhotoStorage photoStorage)
        {
            this.photoStorage = photoStorage;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Photo> uploadPhotoAsync(Product product, IFormFile file, string uploadsFolderPath)
        {
            var fileName = await photoStorage.storePhotoAsync(uploadsFolderPath, file);

            var photo = new Photo { FileName = fileName };
            product.Photos.Add(photo);
            await unitOfWork.CompleteAsync();

            return photo;
        }
    }
}