using bdeliv_services.Extensions;

namespace bdeliv_services.Models
{
    public class ProductQuery : IQueryObject
    {
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
    }
}