using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Web.Models
{
    public class Messages
    {
        [Key]
        public int IdMessage { get; set; }

        [Required]
        public int IdSender { get; set; }

        [Required]
        public int IdReceiver { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public bool Received { get; set; }

        public bool Blocked { get; set; }
    }
}
