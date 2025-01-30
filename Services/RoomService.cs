using Microsoft.EntityFrameworkCore;
using backend.Context;
using backend.Interfaces;
using backend.Entities;

namespace backend.Services
{
    public class RoomService : IRoomService
    {
        private readonly DatabaseContext db;

        public RoomService(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task<Rooms?> GetRoomByIdAsync(int id)
        {
            return await db.Rooms.Where(r => r.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Rooms>> GetPaginatedRoomsListAsync(int pageSize)
        {
            return await db.Rooms.OrderBy(r => r.Id).Take(pageSize).ToListAsync();
        }

        public async Task<Rooms> AddRoomAsync(Rooms room)
        {
            await db.Rooms.AddAsync(room);
            await db.SaveChangesAsync();
            return room;
        }

        public async Task UpdateRoomByIdAsync(Rooms room)
        {
            db.Rooms.Update(room);
            await db.SaveChangesAsync();
        }

        public async Task<bool> DeleteRoomByIdAsync(int id)
        {
            var roomToDelete = await db.Rooms.Where(r => r.Id == id).FirstOrDefaultAsync();
            if(roomToDelete is null)
            {
                return false;
            }

            db.Rooms.Remove(roomToDelete);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
