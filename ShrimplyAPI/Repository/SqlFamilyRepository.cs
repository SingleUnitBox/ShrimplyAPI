using Microsoft.EntityFrameworkCore;
using ShrimplyAPI.Data;
using ShrimplyAPI.Models.Domain;

namespace ShrimplyAPI.Repository
{
    public class SqlFamilyRepository : IFamilyRepository
    {
        private readonly ShrimplyApiDbContext _shrimplyApiDbContext;

        public SqlFamilyRepository(ShrimplyApiDbContext shrimplyApiDbContext)
        {
            _shrimplyApiDbContext = shrimplyApiDbContext;
        }

        public async Task<Family> CreateAsync(Family family)
        {
            await _shrimplyApiDbContext.Families.AddAsync(family);
            await _shrimplyApiDbContext.SaveChangesAsync();
            return family;
        }

        public async Task<Family?> DeleteAsync(Guid id)
        {
            var family = await _shrimplyApiDbContext.Families.FirstOrDefaultAsync(x => x.Id == id);
            if (family == null)
            {
                return null;
            }
            _shrimplyApiDbContext.Families.Remove(family);
            await _shrimplyApiDbContext.SaveChangesAsync();

            return family;
        }

        public async Task<List<Family>> GetAllAsync()
        {
            var families = await _shrimplyApiDbContext.Families.ToListAsync();
            return families;
        }

        public async Task<Family?> GetByIdAsync(Guid id)
        {
            var family = await _shrimplyApiDbContext.Families.FirstOrDefaultAsync(f => f.Id == id);
            return family;
        }

        public async Task<Family> UpdateAsync(Family family, Guid id)
        {
            var familyFromDb = await _shrimplyApiDbContext.Families.FirstOrDefaultAsync(x => x.Id == id);
            if (familyFromDb == null)
            {
                return null;
            }
            familyFromDb.Name = family.Name;
            familyFromDb.Code = family.Code;
            familyFromDb.ImageUrl = family.ImageUrl;
            await _shrimplyApiDbContext.SaveChangesAsync();

            return family;
        }
    }
}
