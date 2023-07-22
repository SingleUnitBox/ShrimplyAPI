using Microsoft.EntityFrameworkCore;
using ShrimplyAPI.Data;
using ShrimplyAPI.Models.Domain;
using System.Linq;

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

        public async Task<List<Shrimp>?> GetAllAsync(
            string? filterOn = null,
            string? filterQuery = null,
            string? sortBy = null,
            bool isAscending = true,
            int pageNumber = 1,
            int pageSize = 1000)
        {
            var shrimps = _shrimplyApiDbContext.Shrimps
                .Include(x => x.Difficulty)
                .Include(x => x.Family)
                .AsQueryable();

            // filter
            if (filterOn != null && filterQuery != null)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    shrimps = shrimps.Where(
                        x => x.Name.Contains(filterQuery));
                }
            }

            //sort
            if (sortBy != null)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    shrimps = isAscending ? shrimps.OrderBy(x => x.Name) : shrimps.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("Description", StringComparison.OrdinalIgnoreCase))
                {
                    shrimps = isAscending ? shrimps.OrderBy(x => x.Description) : shrimps.OrderByDescending(x => x.Description);
                }
            }

            //pagination
            int skip = (pageNumber - 1) * pageSize;
            return await shrimps.Skip(skip).Take(pageSize).ToListAsync();
        }

        public async Task<Shrimp?> GetByIdAsync(Guid id)
        {
            var shrimp = await _shrimplyApiDbContext.Shrimps
                .Include(x => x.Difficulty)
                .Include(x => x.Family)
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
