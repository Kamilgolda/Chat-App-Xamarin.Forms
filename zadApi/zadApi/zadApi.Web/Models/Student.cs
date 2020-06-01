using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Reflection.Metadata;
using Xamarin.Forms;

namespace zadApi.Models
{
    public class Student
    {
        public string Id { get; set; }

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
