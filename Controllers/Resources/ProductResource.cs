using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace bdeliv_services.Controllers.Resources
{

    public class ProductResource
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

        public ICollection<int> Tags { get; set; }

        public ProductResource()
        {
            Tags = new Collection<int>();
        }

    }
}