using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace bdeliv_services.Controllers.Resources
{

    public class SaveProductResource
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public bool Status { get; set; }

        [Required]
        public string Reference { get; set; }

        [Required]
        public string Name { get; set; }

        public string Origin { get; set; }

        public decimal Weight { get; set; }

        public string Measure { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Tax { get; set; }

        public ICollection<int> Tags { get; set; }

        public SaveProductResource()
        {
            Tags = new Collection<int>();
        }

    }
}