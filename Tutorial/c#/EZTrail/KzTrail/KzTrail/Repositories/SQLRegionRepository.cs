using KzTrail.Data;
using KzTrail.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace KzTrail.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly KzTrailDbContext dbContext;

        public SQLRegionRepository(KzTrailDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Regions> createRegionAsync(Regions region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Regions?> deleteRegionAsync(Guid id)
        {
            var existionRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existionRegion == null)
            {
                return null;
            }

            dbContext.Regions.Remove(existionRegion);
            await dbContext.SaveChangesAsync();
            return existionRegion;
        }

        public async Task<List<Regions>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }


        public async Task<Regions?> GetByIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Regions?> updateRegionAsync(Guid id, Regions region)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion == null)
            {
                return null;
            }


            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();
            return existingRegion;


        }
    }
}