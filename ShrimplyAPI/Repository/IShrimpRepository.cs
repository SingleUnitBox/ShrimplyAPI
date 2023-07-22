using Microsoft.AspNetCore.Mvc;
using ShrimplyAPI.Models.Domain;

namespace ShrimplyAPI.Repository
{
    public interface IShrimpRepository
    {
        Task<Shrimp> CreateAsync(Shrimp shrimp);
        Task<List<Shrimp>?> GetAllAsync(
            string? filterOn = null,
            string? filterQuery = null,
            string? sortBy = null,
            bool isAscending = true,
            int pageNumber = 1,
            int pageSize = 1000);
        Task<Shrimp?> GetByIdAsync(Guid id);
        Task<Shrimp?> UpdateAsync(Guid id, Shrimp shrimp);
        Task<Shrimp?> DeleteAsync(Guid id);
    }
}
