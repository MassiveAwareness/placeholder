using Microsoft.EntityFrameworkCore;
using backend.Context;
using backend.Interfaces;
using backend.Entities;

namespace backend.Services
{
    public class SiteService : ISiteService
    {
        private readonly DatabaseContext db;

        public SiteService(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task<Sites?> GetSiteByIdAsync(int id)
        {
            return await db.Sites.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Sites>> GetPaginatedSitesListAsync(int pageSize)
        {
            return await db.Sites.OrderBy(s => s.Id).Take(pageSize).ToListAsync();
        }

        public async Task<Sites> AddSiteAsync(Sites site)
        {
            await db.Sites.AddAsync(site);
            await db.SaveChangesAsync();
            return site;
        }

        public async Task UpdateSiteByIdAsync(Sites site)
        {
            db.Sites.Update(site);
            await db.SaveChangesAsync();
        }

        public async Task<bool> DeleteSiteByIdAsync(int id)
        {
            var siteToDelete = await db.Sites.Where(s => s.Id == id).FirstOrDefaultAsync();
            if(siteToDelete is null)
            {
                return false;
            }

            db.Sites.Remove(siteToDelete);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
