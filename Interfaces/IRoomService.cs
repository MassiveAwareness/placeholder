using backend.Entities;

namespace backend.Interfaces
{
    public interface IRoomService
    {
        Task<Rooms?> GetRoomByIdAsync(int id);
        Task<List<Rooms>> GetPaginatedRoomsListAsync(int pageSize);
        Task<Rooms> AddRoomAsync(Rooms room);
        Task UpdateRoomByIdAsync(Rooms room);
        Task<bool> DeleteRoomByIdAsync(int id);
    }
}
