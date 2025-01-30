using Microsoft.AspNetCore.Mvc;
using backend.Entities;
using backend.Entities.ResponseObjects;
using backend.Interfaces;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CityController : Controller
    {
        private readonly ICityService cityService;

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Cities>> GetCityById(int id)
        {
            Cities? city = await cityService.GetCityByIdAsync(id);
            if(city is null)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    ErrorMessage = $"City with id {id} is not found!"
                });
            }

            return Ok(city);
        }

        [HttpGet]
        public async Task<ActionResult<List<Cities>>> GetAllCities(int pageSize)
        {
            var cities = await cityService.GetPaginatedCitiesListAsync(pageSize);

            return Ok(cities);
        }

        [HttpPost]
        public async Task<ActionResult> AddCity(Cities city)
        {
            var createdCity = await cityService.AddCityAsync(city);
            return Created($"/Cities/Get/{createdCity.Id}", createdCity);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Cities>> UpdateCityDetails(int id, [FromBody] CityUpdateModel model)
        {
            Cities? city = await cityService.GetCityByIdAsync(id);
            if(city is null)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    ErrorMessage = $"No city with id {id} found!"
                });
            }

            city.UpdateCityDetailsAsync(model.CityName);
            await cityService.UpdateCityByIdAsync(city);

            return Ok(city);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCityById(int id)
        {
            var result = await cityService.DeleteCityByIdAsync(id);
            if(!result)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    ErrorMessage = $"No city found with id {id}!"
                });
            }

            return Ok(new { Message = $"City with id {id} has been successfully deleted!" });
        }
    }
}
