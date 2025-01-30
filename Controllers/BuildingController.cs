using Microsoft.AspNetCore.Mvc;
using backend.Entities;
using backend.Entities.ResponseObjects;
using backend.Interfaces;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BuildingController : Controller
    {
        private readonly IBuildingService buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            this.buildingService = buildingService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Buildings>> GetBuildingById(int id)
        {
            Buildings? building = await buildingService.GetBuildingByIdAsync(id);
            if(building is null)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    ErrorMessage = $"Building with id {id} is not found!"
                });
            }

            return Ok(building);
        }

        [HttpGet]
        public async Task<ActionResult<List<Buildings>>> GetAllBuildings(int pageSize)
        {
            var buildings = await buildingService.GetPaginatedBuildingsListAsync(pageSize);
            return Ok(buildings);
        }

        [HttpPost]
        public async Task<ActionResult> AddBuilding(Buildings building)
        {
            var createdBuilding = await buildingService.AddBuildingAsync(building);
            return Created($"/Buildings/Get/{createdBuilding.Id}", createdBuilding);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Buildings>> UpdateBuildingDetails(int id, [FromBody] BuildingUpdateModel model)
        {
            Buildings? building = await buildingService.GetBuildingByIdAsync(id);
            if(building is null)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    ErrorMessage = $"No building with id {id} found!"
                });
            }

            building.UpdateBuildingDetailsAsync(model.BuildingTitle, model.BuildingImg, model.SiteId);
            await buildingService.UpdateBuildingByIdAsync(building);

            return Ok(building);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteBuildingById(int id)
        {
            var result = await buildingService.DeleteBuildingByIdAsync(id);
            if(!result)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    ErrorMessage = $"No building found with id {id}!"
                });
            }

            return Ok(new { Message = $"Building with id {id} has been successfully deleted!" });
        }
    }
}
