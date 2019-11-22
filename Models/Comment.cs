using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Uzduotis_Backend.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime Date { get; set; }

        public int EntryId { get; set; }
        public Entry Entry { get; set; }
    }
}
