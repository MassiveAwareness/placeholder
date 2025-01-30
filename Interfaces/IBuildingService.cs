using backend.Entities;

namespace backend.Interfaces
{
    public interface IBuildingService
    {
        Task<Buildings?> GetBuildingByIdAsync(int id);
        Task<List<Buildings>> GetPaginatedBuildingsListAsync(int pageSize);
        Task<Buildings> AddBuildingAsync(Buildings building);
        Task UpdateBuildingByIdAsync(Buildings building);
        Task<bool> DeleteBuildingByIdAsync(int id);
    }
}
