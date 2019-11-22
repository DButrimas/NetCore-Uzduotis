using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uzduotis_Backend.Models;

namespace Uzduotis_Backend.Data
{
    public class EntryContext : DbContext
    {
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public EntryContext(DbContextOptions<EntryContext> options)
            : base(options)
        {

        }
    
    }
}
