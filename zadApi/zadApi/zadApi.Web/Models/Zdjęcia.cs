using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zadApi.Models
{
    public class Zdjęcia
    {
        public int Id { get; set; }
        [Required]
        public int IdStudent { get; set; }
        

        [Required]
        public byte[] Zdjęcie { get; set; }
    }
}
