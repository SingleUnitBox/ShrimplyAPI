using ShrimplyAPI.Models.Domain;

namespace ShrimplyAPI.Repository
{
    public interface IShrimpRepository
    {
        Task<Shrimp> CreateAsync(Shrimp shrimp);
        Task<List<Shrimp>?> GetAllAsync();
        Task<Shrimp?> GetByIdAsync(Guid id);
        Task<Shrimp?> UpdateAsync(Guid id, Shrimp shrimp);
        Task<Shrimp?> DeleteAsync(Guid id);
    }
}
