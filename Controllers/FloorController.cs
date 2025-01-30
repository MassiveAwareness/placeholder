using Microsoft.AspNetCore.Mvc;
using backend.Entities;
using backend.Entities.ResponseObjects;
using backend.Interfaces;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FloorController : Controller
    {
        private readonly IFloorService floorService;

        public FloorController(IFloorService floorService)
        {
            this.floorService = floorService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Floors?>> GetFloorById(int id)
        {
            Floors? floor = await floorService.GetFloorByIdAsync(id);
            if(floor is null)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    ErrorMessage = $"Floor with id {id} is not found!"
                });
            }

            return Ok(floor);
        }

        [HttpGet]
        public async Task<ActionResult<List<Floors>>> GetAllFloors(int pageSize)
        {
            var floors = await floorService.GetPaginatedFloorsListAsync(pageSize);
            return Ok(floors);
        }

        [HttpPost]
        public async Task<ActionResult> AddFloor(Floors floor)
        {
            var createdFloor = await floorService.AddFloorAsync(floor);
            return Created($"/Floors/Get/{createdFloor.Id}", createdFloor);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Floors>> UpdateFloorDetails(int id, [FromBody] FloorUpdateModel model)
        {
            Floors? floor = await floorService.GetFloorByIdAsync(id);
            if(floor is null)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    ErrorMessage = $"No floors with id {id} found!"
                });
            }

            floor.UpdateFloorDetailsAsync(model.FloorTitle, model.BuildingId);
            await floorService.UpdateFloorByIdAsync(floor);

            return Ok(floor);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteFloorById(int id)
        {
            var result = await floorService.DeleteFloorByIdAsync(id);
            if(!result)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    ErrorMessage = $"No floor found with id {id}"
                });
            }

            return Ok(new { Message = $"Floor with id {id} has been successfully deleted!" });
        }
    }
}
