using Microsoft.EntityFrameworkCore;
using SzaboGlass.Data.Entity;

namespace SzaboGlass.Data
{
    public partial class Program : DbContext
    {
        public Program() { }

        public Program(DbContextOptions<Program> options) : base(options) { }

        public virtual DbSet<Glass> Glasses { get; set; }
        public virtual DbSet<GlassType> GlassTypes { get; set; }
    }
}
