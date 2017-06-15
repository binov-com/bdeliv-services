using System.Collections.Generic;
using System.Threading.Tasks;
using bdeliv_services.Models;

namespace bdeliv_services.Core
{
    public interface IPhotoRepository
    {
         Task<IEnumerable<Photo>> GetPhotos(int productId);
    }
}