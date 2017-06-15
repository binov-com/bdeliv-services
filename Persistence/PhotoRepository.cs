using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bdeliv_services.Core;
using bdeliv_services.Models;
using Microsoft.EntityFrameworkCore;

namespace bdeliv_services.Persistence
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly BdelivDbContext context;
        public PhotoRepository(BdelivDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Photo>> GetPhotos(int productId)
        {
            return await context.Photos
                .Where(p => p.ProductId == productId)
                .ToListAsync();
        }
    }
}