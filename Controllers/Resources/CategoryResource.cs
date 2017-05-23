using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace bdeliv_services.Controllers.Resources
{
    public class CategoryResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }

        public decimal Tax { get; set; }

        public string ImgPath { get; set; }

        public string ImgName { get; set; }

        public ICollection<ProductResource> Products { get; set; }

        public CategoryResource()
        {
            Products = new Collection<ProductResource>();
        }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}