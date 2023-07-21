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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var families = new List<Family>
            {
                new Family { Id = Guid.NewGuid(), Name = "Caridina", Code = "CAR", ImageUrl = "image1" },
                new Family { Id = Guid.NewGuid(), Name = "Neocaridina", Code = "NEO", ImageUrl = "image2" },
                new Family { Id = Guid.NewGuid(), Name = "Sulawesi", Code = "SUL", ImageUrl = "image3" },
            };
            modelBuilder.Entity<Family>().HasData(families);

            var difficulties = new List<Difficulty>
            {
                new Difficulty { Id = Guid.NewGuid(), Name = "Easy" },
                new Difficulty { Id = Guid.NewGuid(), Name = "Medium" },
                new Difficulty { Id = Guid.NewGuid(), Name = "Hard" },
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);
        }
    }
}


