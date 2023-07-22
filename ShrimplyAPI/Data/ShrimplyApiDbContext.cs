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
                new Family { Id = Guid.Parse("58ba0c1c-d7ef-4b22-80a9-8adf8c442b02"), Name = "Caridina", Code = "CAR", ImageUrl = "image1" },
                new Family { Id = Guid.Parse("58ba0c1c-d7ef-4b22-80a9-8adf8c442b03"), Name = "Neocaridina", Code = "NEO", ImageUrl = "image2" },
                new Family { Id = Guid.Parse("58ba0c1c-d7ef-4b22-80a9-8adf8c442b04"), Name = "Sulawesi", Code = "SUL", ImageUrl = "image3" },
            };
            modelBuilder.Entity<Family>().HasData(families);

            var difficulties = new List<Difficulty>
            {
                new Difficulty { Id = Guid.Parse("58ba0c1c-d7ef-4b22-80a9-8adf8c442b05"), Name = "Easy" },
                new Difficulty { Id = Guid.Parse("58ba0c1c-d7ef-4b22-80a9-8adf8c442b06"), Name = "Medium" },
                new Difficulty { Id = Guid.Parse("58ba0c1c-d7ef-4b22-80a9-8adf8c442b07"), Name = "Hard" },
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var shrimps = new List<Shrimp>
            {
                new Shrimp
                {   Id = Guid.NewGuid(),
                    Name = "Pure White Line",
                    Description = "Pure White Line Shrimp",
                    ImageUrl = "image4",
                    DifficultyId = Guid.Parse("58ba0c1c-d7ef-4b22-80a9-8adf8c442b06"),
                    FamilyId = Guid.Parse("58ba0c1c-d7ef-4b22-80a9-8adf8c442b02"),
                },
                new Shrimp
                {   Id = Guid.NewGuid(),
                    Name = "Pure Red Line",
                    Description = "Pure Red Line Shrimp",
                    ImageUrl = "image5",
                    DifficultyId = Guid.Parse("58ba0c1c-d7ef-4b22-80a9-8adf8c442b06"),
                    FamilyId = Guid.Parse("58ba0c1c-d7ef-4b22-80a9-8adf8c442b02"),
                },
                new Shrimp
                {   Id = Guid.NewGuid(),
                    Name = "Pure Black Line",
                    Description = "Pure Black Line Shrimp",
                    ImageUrl = "image6",
                    DifficultyId = Guid.Parse("58ba0c1c-d7ef-4b22-80a9-8adf8c442b06"),
                    FamilyId = Guid.Parse("58ba0c1c-d7ef-4b22-80a9-8adf8c442b02"),
                },
                new Shrimp
                {   Id = Guid.NewGuid(),
                    Name = "Yellow",
                    Description = "Yellow Shrimp",
                    ImageUrl = "image7",
                    DifficultyId = Guid.Parse("58ba0c1c-d7ef-4b22-80a9-8adf8c442b05"),
                    FamilyId = Guid.Parse("58ba0c1c-d7ef-4b22-80a9-8adf8c442b03"),
                },
                new Shrimp
                {   Id = Guid.NewGuid(),
                    Name = "White Pearl",
                    Description = "White Pearl",
                    ImageUrl = "image8",
                    DifficultyId = Guid.Parse("58ba0c1c-d7ef-4b22-80a9-8adf8c442b05"),
                    FamilyId = Guid.Parse("58ba0c1c-d7ef-4b22-80a9-8adf8c442b03"),
                },
                new Shrimp
                {   Id = Guid.NewGuid(),
                    Name = "Cardinal",
                    Description = "Cardinal",
                    ImageUrl = "image9",
                    DifficultyId = Guid.Parse("58ba0c1c-d7ef-4b22-80a9-8adf8c442b07"),
                    FamilyId = Guid.Parse("58ba0c1c-d7ef-4b22-80a9-8adf8c442b04"),
                },
            };
            modelBuilder.Entity<Shrimp>().HasData(shrimps);
        }
    }
}


