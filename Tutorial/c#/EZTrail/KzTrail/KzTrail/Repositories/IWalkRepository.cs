using KzTrail.Models.Domain;

namespace KzTrail.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000);
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk?> updateWalkAsync(Guid id, Walk walk);

        Task<Walk?> deleteWalkAsync(Guid id);

    }
}
