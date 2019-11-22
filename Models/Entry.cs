using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Uzduotis_Backend.Models
{
    public class Entry
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
        public DateTime Date { get; set; }

        public int CommentsCount { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
