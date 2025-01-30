using Microsoft.EntityFrameworkCore;
using backend.Context;
using backend.Interfaces;
using backend.Entities;

namespace backend.Services
{
    public class CityService : ICityService
    {
        private readonly DatabaseContext db;

        public CityService(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task<Cities?> GetCityByIdAsync(int id)
        {
            return await db.Cities.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Cities>> GetPaginatedCitiesListAsync(int pageSize)
        {
            return await db.Cities.OrderBy(c => c.Id).Take(pageSize).ToListAsync();
        }

        public async Task<Cities> AddCityAsync(Cities city)
        {
            await db.Cities.AddAsync(city);
            await db.SaveChangesAsync();
            return city;
        }

        public async Task UpdateCityByIdAsync(Cities city)
        {
            db.Cities.Update(city);
            await db.SaveChangesAsync();
        }

        public async Task<bool> DeleteCityByIdAsync(int id)
        {
            var cityToDelete = await db.Cities.Where(c => c.Id == id).FirstOrDefaultAsync();
            if(cityToDelete is null)
            {
                return false;
            }

            db.Cities.Remove(cityToDelete);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
