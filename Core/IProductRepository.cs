using System.Collections.Generic;
using System.Threading.Tasks;
using bdeliv_services.Models;

namespace bdeliv_services.Core
{
    public interface IProductRepository
    {
        Task<QueryResult<Product>> GetProducts(ProductQuery filter);
        Task<Product> GetProduct(int id, bool includeRelated = false);
        void Add(Product product);
        void Remove(Product product);
    }
}