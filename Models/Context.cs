using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabIt.Models
{
    public class Context : DbContext
    {
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
