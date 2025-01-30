using backend.Entities;

namespace backend.Interfaces
{
    public interface ICityService
    {
        Task<Cities?> GetCityByIdAsync(int id);
        Task<List<Cities>> GetPaginatedCitiesListAsync(int pageSize);
        Task<Cities> AddCityAsync(Cities city);
        Task UpdateCityByIdAsync(Cities city);
        Task<bool> DeleteCityByIdAsync(int id);
    }
}
