using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShrimplyAPI.Entities;

namespace ShrimplyAPI.Repositories
{
    public interface IShrimpsRepository
    {
        Shrimp GetShrimp(Guid shrimpId);
        IEnumerable<Shrimp> GetShrimps();
        void CreateShrimp(Shrimp shrimp);
        void UpdateShrimp(Shrimp shrimp);
        void DeleteShrimp(Guid id);
    }
}