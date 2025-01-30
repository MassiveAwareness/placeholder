using Microsoft.AspNetCore.Mvc;
using backend.Entities;
using backend.Entities.ResponseObjects;
using backend.Interfaces;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SiteController : Controller
    {
        private readonly ISiteService siteService;

        public SiteController(ISiteService siteService)
        {
            this.siteService = siteService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Sites>> GetSiteById(int id)
        {
            Sites? site = await siteService.GetSiteByIdAsync(id);
            if(site is null)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    ErrorMessage = $"Site with id {id} is not found!"
                });
            }

            return Ok(site);
        }

        [HttpGet]
        public async Task<ActionResult<List<Sites>>> GetAllSites(int pageSize)
        {
            var sites = await siteService.GetPaginatedSitesListAsync(pageSize);
            return Ok(sites);
        }

        [HttpPost]
        public async Task<ActionResult> AddSite(Sites site)
        {
            var createdSite = await siteService.AddSiteAsync(site);
            return Created($"Sites/Get/{createdSite.Id}", createdSite);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Sites>> UpdateSiteDetails(int id, [FromBody] SiteUpdateModel model)
        {
            Sites? site = await siteService.GetSiteByIdAsync(id);
            if(site is null)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    ErrorMessage = $"No site with id {id} found!"
                });
            }

            site.UpdateSiteDetailsAsync(model.SiteTitle, model.SiteImage, model.CityId);
            await siteService.UpdateSiteByIdAsync(site);

            return Ok(site);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCityById(int id)
        {
            var result = await siteService.DeleteSiteByIdAsync(id);
            if(!result)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    ErrorMessage = $"No site found with id {id}"
                });
            }

            return Ok(new { Message = $"Site with id {id} has been successfully deleted!" });
        }
    }
}
