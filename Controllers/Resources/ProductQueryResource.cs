namespace bdeliv_services.Controllers.Resources
{
    public class ProductQueryResource
    {
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
    }
}