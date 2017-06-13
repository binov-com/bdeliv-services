using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bdeliv_services.Models
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }

        public bool Status { get; set; }

        [Required]
        [StringLength(128)]
        public string Reference { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(128)]
        public string Origin { get; set; }

        public decimal Weight { get; set; }

        [StringLength(32)]
        public string Measure { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Tax { get; set; }

        [StringLength(128)]
        public string ImgName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public ICollection<ProductTags> Tags { get; set; }
        public ICollection<Photo> Photos { get; set; }

        public Product()
        {
            Tags = new Collection<ProductTags>();
            Photos = new Collection<Photo>();
        }
    }
}