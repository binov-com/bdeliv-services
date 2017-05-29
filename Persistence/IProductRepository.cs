using System.Threading.Tasks;
using bdeliv_services.Models;

namespace bdeliv_services.Persistence
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(int id);
    }
}