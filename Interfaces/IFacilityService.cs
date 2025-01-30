using backend.Entities;

namespace backend.Interfaces
{
    public interface IFacilityService
    {
        Task<Facilities?> GetFacilityByIdAsync(int id);
        Task<List<Facilities>> GetPaginatedFacilitiesListAsync(int pageSize);
        Task<Facilities> AddFacilityAsync(Facilities facility);
        Task UpdateFacilityByIdAsync(Facilities facility);
        Task<bool> DeleteFacilityByIdAsync(int id);
    }
}
