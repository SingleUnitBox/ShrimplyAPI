using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShrimplyAPI.Entities;

namespace ShrimplyAPI.Repositories
{

    public class InMemShrimpsRepository : IInMemShrimpsRepository
    {
        private readonly List<Shrimp> shrimps = new()
        {
            new Shrimp { Id = Guid.NewGuid(), Name = "Calceo Red", Price = 4.99m, DateCreated = DateTimeOffset.UtcNow },
            new Shrimp { Id = Guid.NewGuid(), Name = "Pure Red Line", Price = 2.99m, DateCreated = DateTimeOffset.UtcNow },
            new Shrimp { Id = Guid.NewGuid(), Name = "Dragon Blood", Price = 5.99m, DateCreated = DateTimeOffset.UtcNow }
        };
        public IEnumerable<Shrimp> GetShrimps()
        {
            return shrimps;
        }
        public Shrimp GetShrimp(Guid shrimpId)
        {
            return shrimps.Where(shrimp => shrimp.Id == shrimpId).SingleOrDefault();
        }
    }
}