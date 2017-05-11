using System;
using System.ComponentModel.DataAnnotations;

namespace bdeliv_services.Models
{
    public class User
    {
        public int Id { get; set; }

        public bool Status { get; set; }

        public bool IsAdmin { get; set; }

        [StringLength(8)]
        public string Gender { get; set; }

        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128)]
        public string LastName { get; set; }

        [StringLength(16)]
        public string Phone { get; set; }

        [StringLength(16)]
        public string Mobile { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        [StringLength(256)]
        public string Password { get; set; }

        [StringLength(256)]
        public string Hash { get; set; }

        public bool Valid { get; set; } // Password Management

        [StringLength(1024)]
        public string Comment { get; set; }

        public DateTime LastLoginAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}