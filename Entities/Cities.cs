using backend.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Cities
    {
        [Key]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }

        [Required]
        public string CityName { get; set; } = string.Empty;

        public Cities UpdateCityDetailsAsync(string cityName)
        {
            this.CityName = cityName;

            return this;
        }

        public Cities() {  }

        public Cities(CityUpdateModel model)
        {
            Id = model.Id;
            CityName = model.CityName;
        }
    }
}
