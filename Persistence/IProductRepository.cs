using System.Threading.Tasks;
using bdeliv_services.Models;

namespace bdeliv_services.Persistence
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(int id, bool includeRelated = false);
        void Add(Product product);
        void Remove(Product product);
    }
}