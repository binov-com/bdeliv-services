using System.Threading.Tasks;
using bdeliv_services.Models;
using Microsoft.AspNetCore.Http;

namespace bdeliv_services.Core
{
    public interface IPhotoService
    {
         Task<Photo> uploadPhotoAsync(Product product, IFormFile file, string uploadsFolderPath);
    }
}