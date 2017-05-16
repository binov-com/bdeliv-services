using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bdeliv_services.Models
{
    [Table("Clients")]
    public class Client
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        [StringLength(8)]
        public string Gender { get; set; }

        [Required]
        [StringLength(128)]
        public string LastName { get; set; }

        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }

        [StringLength(16)]
        public string Phone { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        [StringLength(256)]
        public string Password { get; set; }

        [StringLength(256)]
        public string Hash { get; set; }

        public bool Valid { get; set; } // Password Management

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}