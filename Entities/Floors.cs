using backend.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Floors
    {
        [Key]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }

        [Required]
        public string FloorTitle { get; set; } = string.Empty;

        [Required]
        public int BuildingId { get; set; }

        public Floors UpdateFloorDetailsAsync(string floorTitle, int buildingId)
        {
            this.FloorTitle = floorTitle;
            this.BuildingId = buildingId;

            return this;
        }

        public Floors() {  }

        public Floors(FloorUpdateModel model)
        {
            Id = model.Id;
            FloorTitle = model.FloorTitle;
            BuildingId = model.BuildingId;
        }
    }
}
