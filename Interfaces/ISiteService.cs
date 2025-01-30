using backend.Entities;

namespace backend.Interfaces
{
    public interface ISiteService
    {
        Task<Sites?> GetSiteByIdAsync(int id);
        Task<List<Sites>> GetPaginatedSitesListAsync(int pageSize);
        Task<Sites> AddSiteAsync(Sites site);
        Task UpdateSiteByIdAsync(Sites site);
        Task<bool> DeleteSiteByIdAsync(int id);
    }
}
