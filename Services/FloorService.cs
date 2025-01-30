using Microsoft.EntityFrameworkCore;
using backend.Context;
using backend.Interfaces;
using backend.Entities;

namespace backend.Services
{
    public class FloorService : IFloorService
    {
        private readonly DatabaseContext db;

        public FloorService(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task<Floors?> GetFloorByIdAsync(int id)
        {
            return await db.Floors.Where(f => f.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Floors>> GetPaginatedFloorsListAsync(int pageSize)
        {
            return await db.Floors.OrderBy(f => f.Id).Take(pageSize).ToListAsync();
        }

        public async Task<Floors> AddFloorAsync(Floors floor)
        {
            await db.Floors.AddAsync(floor);
            await db.SaveChangesAsync();
            return floor;
        }

        public async Task UpdateFloorByIdAsync(Floors floor)
        {
            db.Floors.Update(floor);
            await db.SaveChangesAsync();
        }

        public async Task<bool> DeleteFloorByIdAsync(int id)
        {
            var floorToDelete = await db.Floors.Where(f => f.Id == id).FirstOrDefaultAsync();
            if(floorToDelete is null)
            {
                return false;
            }

            db.Floors.Remove(floorToDelete);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
