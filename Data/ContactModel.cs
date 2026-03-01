using System;
using System.ComponentModel.DataAnnotations;

namespace CyberpunkBackend.Data
{
    public class ContactModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
