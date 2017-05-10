using System;

namespace bdeliv_services.Models
{
    public class Product
    {
        public int Id { get; set; }

        public bool Status { get; set; }

        public string Reference { get; set; }

        public string Name { get; set; }

        public string Origin { get; set; }

        public decimal Weight { get; set; }

        public string Measure { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Tax { get; set; }

        public string ImgName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}