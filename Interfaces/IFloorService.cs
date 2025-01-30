using backend.Entities;

namespace backend.Interfaces
{
    public interface IFloorService
    {
        Task<Floors?> GetFloorByIdAsync(int id);
        Task<List<Floors>> GetPaginatedFloorsListAsync(int pageSize);
        Task<Floors> AddFloorAsync(Floors floor);
        Task UpdateFloorByIdAsync(Floors floor);
        Task<bool> DeleteFloorByIdAsync(int id);
    }
}
