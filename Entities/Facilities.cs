using backend.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Facilities
    {
        [Key]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }

        [Required]
        public string Attributes { get; set; } = string.Empty;

        [Required]
        public int Value { get; set; }

        [Required]
        public int RoomId { get; set; }

        public Facilities UpdateFacilityDetailsAsync(string attributes, int value, int roomId)
        {
            this.Attributes = attributes;
            this.Value = value;
            this.RoomId = roomId;

            return this;
        }

        public Facilities() {  }

        public Facilities(FacilityUpdateModel model)
        {
            Id = model.Id;
            Attributes = model.Attributes;
            Value = model.Value;
            RoomId = model.RoomId;
        }
    }
}
