using Microsoft.EntityFrameworkCore;
using backend.Context;
using backend.Interfaces;
using backend.Entities;

namespace backend.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly DatabaseContext db;

        public BuildingService(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task<Buildings?> GetBuildingByIdAsync(int id)
        {
            return await db.Buildings.Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Buildings>> GetPaginatedBuildingsListAsync(int pageSize)
        {
            return await db.Buildings.OrderBy(b => b.Id).Take(pageSize).ToListAsync();
        }

        public async Task<Buildings> AddBuildingAsync(Buildings building)
        {
            await db.Buildings.AddAsync(building);
            await db.SaveChangesAsync();
            return building;
        }

        public async Task UpdateBuildingByIdAsync(Buildings building)
        {
            db.Buildings.Update(building);
            await db.SaveChangesAsync();
        }

        public async Task<bool> DeleteBuildingByIdAsync(int id)
        {
            var buildingToDelete = await db.Buildings.Where(b => b.Id == id).FirstOrDefaultAsync();
            if(buildingToDelete is null)
            {
                return false;
            }

            db.Buildings.Remove(buildingToDelete);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
