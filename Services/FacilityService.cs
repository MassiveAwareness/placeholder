using Microsoft.EntityFrameworkCore;
using backend.Context;
using backend.Interfaces;
using backend.Entities;

namespace backend.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly DatabaseContext db;

        public FacilityService(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task<Facilities?> GetFacilityByIdAsync(int id)
        {
            return await db.Facilities.Where(f => f.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Facilities>> GetPaginatedFacilitiesListAsync(int pageSize)
        {
            return await db.Facilities.OrderBy(f => f.Id).Take(pageSize).ToListAsync();
        }

        public async Task<Facilities> AddFacilityAsync(Facilities facility)
        {
            await db.Facilities.AddAsync(facility);
            await db.SaveChangesAsync();
            return facility;
        }

        public async Task UpdateFacilityByIdAsync(Facilities facility)
        {
            db.Facilities.Update(facility);
            await db.SaveChangesAsync();
        }

        public async Task<bool> DeleteFacilityByIdAsync(int id)
        {
            var facilityToDelete = await db.Facilities.Where(f => f.Id == id).FirstOrDefaultAsync();
            if(facilityToDelete is null)
            {
                return false;
            }

            db.Facilities.Remove(facilityToDelete);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
