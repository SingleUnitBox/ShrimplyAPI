using Microsoft.EntityFrameworkCore;
using ShrimplyAPI.Data;
using ShrimplyAPI.Models.Domain;

namespace ShrimplyAPI.Repository
{
    public class SqlShrimpRepository : IShrimpRepository
    {
        private readonly ShrimplyApiDbContext _shrimplyApiDbContext;

        public SqlShrimpRepository(ShrimplyApiDbContext shrimplyApiDbContext)
        {
            _shrimplyApiDbContext = shrimplyApiDbContext;
        }
        public async Task<Shrimp> CreateAsync(Shrimp shrimp)
        {
            await _shrimplyApiDbContext.Shrimps.AddAsync(shrimp);
            await _shrimplyApiDbContext.SaveChangesAsync();
            return shrimp;
        }

        public async Task<Shrimp?> DeleteAsync(Guid id)
        {
            var shrimp = await _shrimplyApiDbContext.Shrimps.FirstOrDefaultAsync(x => x.Id == id);
            if (shrimp == null)
            {
                return null;
            }
            _shrimplyApiDbContext.Shrimps.Remove(shrimp);
            await _shrimplyApiDbContext.SaveChangesAsync();
            return shrimp;
        }

        public async Task<List<Shrimp>?> GetAllAsync()
        {
            var shrimps = await _shrimplyApiDbContext.Shrimps
                .Include(x => x.Difficulty)
                .Include(x => x.Family)
                .ToListAsync();
            if (shrimps == null)
            {
                return null;
            }
            return shrimps;
        }

        public async Task<Shrimp?> GetByIdAsync(Guid id)
        {
            var shrimp = await _shrimplyApiDbContext.Shrimps
                .Include(x => x.Difficulty)
                .Include (x => x.Family)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (shrimp == null)
            {
                return null;
            }
            return shrimp;
        }

        public async Task<Shrimp?> UpdateAsync(Guid id, Shrimp shrimp)
        {
            var shrimpFromDb = await _shrimplyApiDbContext.Shrimps
                .Include(f => f.Family)
                .Include(d => d.Difficulty)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (shrimpFromDb == null)
            {
                return null;
            }

            shrimpFromDb.Name = shrimp.Name;
            shrimpFromDb.Description = shrimp.Description;
            shrimpFromDb.ImageUrl = shrimp.ImageUrl;
            shrimpFromDb.DifficultyId = shrimp.DifficultyId;
            shrimpFromDb.FamilyId = shrimp.FamilyId;
            await _shrimplyApiDbContext.SaveChangesAsync();

            return shrimpFromDb;
        }

    }
}
