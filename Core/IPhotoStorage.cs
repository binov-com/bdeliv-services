using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace bdeliv_services.Core
{
    public interface IPhotoStorage
    {
         Task<string> storePhotoAsync(string uploadsFolderPath, IFormFile file);
    }
}