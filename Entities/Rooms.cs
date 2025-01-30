using backend.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Rooms
    {
        [Key]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }

        [Required]
        public string RoomName { get; set; } = string.Empty;

        [Required]
        public string RoomBuildingImg { get; set; } = string.Empty;

        [Required]
        public string RoomSiteImg { get; set; } = string.Empty;

        [Required]
        public string RoomTitle { get; set; } = string.Empty;

        [Required]
        public string RoomImg { get; set; } = string.Empty;

        [Required]
        public string RoomEquipImg { get; set; } = string.Empty;

        [Required]
        public int FloorId { get; set; }

        public Rooms UpdateRoomDetailsAsync(string roomName, string roomBuildingImg, string roomSiteImg, string roomTitle, string roomImg, string roomEquipImg, int floorId)
        {
            this.RoomName = roomName;
            this.RoomBuildingImg = roomBuildingImg;
            this.RoomSiteImg = roomSiteImg;
            this.RoomTitle = roomTitle;
            this.RoomImg = roomImg;
            this.RoomEquipImg = roomEquipImg;
            this.FloorId = floorId;

            return this;
        }

        public Rooms() {  }

        public Rooms(RoomUpdateModel model)
        {
            Id = model.Id;
            RoomName = model.RoomName;
            RoomBuildingImg = model.RoomBuildingImg;
            RoomSiteImg = model.RoomSiteImg;
            RoomTitle = model.RoomTitle;
            RoomImg = model.RoomImg;
            RoomEquipImg = model.RoomEquipImg;
            FloorId = model.FloorId;
        }
    }
}
