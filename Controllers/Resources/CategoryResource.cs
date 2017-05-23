using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace bdeliv_services.Controllers.Resources
{
    public class CategoryResource : KeyValuePairResource
    {
        public bool Status { get; set; }

        public decimal Tax { get; set; }

        public string ImgPath { get; set; }

        public string ImgName { get; set; }

        public ICollection<ProductResource> Products { get; set; }

        public CategoryResource()
        {
            Products = new Collection<ProductResource>();
        }
    }
}