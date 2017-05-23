using System;

namespace bdeliv_services.Controllers.Resources
{
    public class TagResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}