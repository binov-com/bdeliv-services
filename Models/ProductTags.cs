using System.ComponentModel.DataAnnotations.Schema;

namespace bdeliv_services.Models
{
    [Table("ProductTags")]
    public class ProductTags
    {
        public int ProductId { get; set; }

        public int TagId { get; set; }

        public Product Product { get; set; }

        public Tag Tag { get; set; }
    }
}