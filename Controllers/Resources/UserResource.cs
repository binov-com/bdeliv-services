using System;

namespace bdeliv_services.Controllers.Resources
{
    public class UserResource
    {
        public int Id { get; set; }

        public bool Status { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsDelivery { get; set; }
        
        public string Gender { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public bool Valid { get; set; } // Password Management

        public string Comment { get; set; }

        public DateTime LastLoginAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}