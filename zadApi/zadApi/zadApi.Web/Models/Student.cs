using System;
using System.ComponentModel.DataAnnotations;

namespace zadApi.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Imie { get; set; }

        [Required]
        public string Nazwisko { get; set; }

        [Required]
        public string NrAlbumu { get; set; }

        [Required]
        public string Plec { get; set; }
    }
}
