using Microsoft.AspNetCore.Mvc;
using backend.Entities;
using backend.Entities.ResponseObjects;
using backend.Interfaces;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FacilityController : Controller
    {
        private readonly IFacilityService facilityService;

        public FacilityController(IFacilityService facilityService)
        {
            this.facilityService = facilityService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Facilities>> GetFacilityById(int id)
        {
            Facilities? facility = await facilityService.GetFacilityByIdAsync(id);
            if(facility is null)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    ErrorMessage = $"Facility with id {id} is not found!"
                });
            }

            return Ok(facility);
        }

        [HttpGet]
        public async Task<ActionResult<List<Facilities>>> GetAllFacilities(int pageSize)
        {
            var facilities = await facilityService.GetPaginatedFacilitiesListAsync(pageSize);
            return Ok(facilities);
        }

        [HttpPost]
        public async Task<ActionResult> AddFacility(Facilities facility)
        {
            var createdFacility = await facilityService.AddFacilityAsync(facility);
            return Created($"/Facilities/Get/{createdFacility.Id}", createdFacility);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Facilities>> UpdateFacilityDetails(int id, [FromBody] FacilityUpdateModel model)
        {
            Facilities? facility = await facilityService.GetFacilityByIdAsync(id);
            if(facility is null)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    ErrorMessage = $"No facility with id {id} found!"
                });
            }

            facility.UpdateFacilityDetailsAsync(model.Attributes, model.Value, model.RoomId);
            await facilityService.UpdateFacilityByIdAsync(facility);

            return Ok(facility);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCityById(int id)
        {
            var result = await facilityService.DeleteFacilityByIdAsync(id);
            if(!result)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    ErrorMessage = $"No facility with id {id} found!"
                });
            }

            return Ok(new { Message = $"Facility with id {id} has been successfully deleted!" });
        }
    }
}
