using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace bdeliv_services.Models
{
    public class Category
    {
        public int Id { get; set; }

        public bool Status { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public decimal Tax { get; set; }

        [StringLength(128)]
        public string ImgPath { get; set; }

        [StringLength(512)]
        public string ImgName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new Collection<Product>();
        }
    }
}