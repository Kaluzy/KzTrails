using KzTrail.Models.Domain;

namespace KzTrail.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Regions>> GetAllAsync();

        Task<Regions?> GetByIdAsync(Guid id);

        Task<Regions> createRegionAsync(Regions region);

        Task<Regions?> updateRegionAsync(Guid id, Regions region);

        Task<Regions?> deleteRegionAsync(Guid id);
    }
}
