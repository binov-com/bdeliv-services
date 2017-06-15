using System.ComponentModel.DataAnnotations;

namespace bdeliv_services.Models
{
    public class Photo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; }

        public int ProductId { get; set; }
    }
}