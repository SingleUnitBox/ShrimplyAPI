using Microsoft.EntityFrameworkCore;
using ShrimplyAPI.Models.Domain;

namespace ShrimplyAPI.Data
{
    public class ShrimplyApiDbContext : DbContext
    {
        public ShrimplyApiDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Shrimp> Shrimps { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
    }
}


