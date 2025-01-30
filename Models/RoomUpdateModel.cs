using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class RoomUpdateModel
    {
        public int Id { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public string RoomBuildingImg { get; set; } = string.Empty;
        public string RoomSiteImg { get; set; } = string.Empty;
        public string RoomTitle { get; set; } = string.Empty;
        public string RoomImg { get; set; } = string.Empty;
        public string RoomEquipImg { get; set; } = string.Empty;
        public int FloorId { get; set; }
    }
}
