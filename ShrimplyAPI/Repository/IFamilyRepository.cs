using ShrimplyAPI.Models.Domain;

namespace ShrimplyAPI.Repository
{
    public interface IFamilyRepository
    {
        Task<List<Family>> GetAllAsync();
        Task<Family?> GetByIdAsync(Guid id);
        Task<Family> CreateAsync(Family family);
        Task<Family?> UpdateAsync(Family family, Guid id);
        Task<Family?> DeleteAsync(Guid id);
    }
}
