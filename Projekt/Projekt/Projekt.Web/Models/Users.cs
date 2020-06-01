using System;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class Users
    {
        [Key]
        public int IdUser { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime Dateofbirth { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
