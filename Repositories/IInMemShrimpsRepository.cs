using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShrimplyAPI.Entities;

namespace ShrimplyAPI.Repositories
{
    public interface IInMemShrimpsRepository
    {
        Shrimp GetShrimp(Guid shrimpId);
        IEnumerable<Shrimp> GetShrimps();
    }
}