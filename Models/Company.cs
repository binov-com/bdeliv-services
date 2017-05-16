using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace bdeliv_services.Models
{
    public class Company
    {
        public int Id { get; set; }

        [StringLength(64)]
        public string Registration { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required]
        [StringLength(16)]
        public string Zip { get; set; }

        [Required]
        [StringLength(128)]
        public string City { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<Client> Clients { get; set; }

        public Company()
        {
            Clients = new Collection<Client>();
        }

    }
}