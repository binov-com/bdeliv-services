using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace bdeliv_services.Controllers.Resources
{
    public class ProductResource : KeyValuePairResource
    {
        public bool Status { get; set; }

        public string Reference { get; set; }

        public string Origin { get; set; }

        public decimal Weight { get; set; }

        public string Measure { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Tax { get; set; }

        public string ImgName { get; set; }

        public CategoryResource Category { get; set; }

        public ICollection<KeyValuePairResource> Tags { get; set; }

        public ProductResource()
        {
            Tags = new Collection<KeyValuePairResource>();
        }
    }
}