using Microsoft.AspNetCore.Mvc;
using backend.Entities;
using backend.Entities.ResponseObjects;
using backend.Interfaces;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RoomControllers : Controller
    {
        private readonly IRoomService roomService;

        public RoomControllers(IRoomService roomService)
        {
            this.roomService = roomService;
        }   

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Rooms>> GetRoomById(int id)
        {
            Rooms? room = await roomService.GetRoomByIdAsync(id);
            if(room is null)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    ErrorMessage = $"Room with id {id} is not found!"
                });
            }

            return Ok(room);
        }

        [HttpGet]
        public async Task<ActionResult<List<Rooms>>> GetAllRooms(int pageSize)
        {
            var rooms = await roomService.GetPaginatedRoomsListAsync(pageSize);
            return Ok(rooms);
        }

        [HttpPost]
        public async Task<ActionResult> AddRoom(Rooms room)
        {
            var createdRoom = await roomService.AddRoomAsync(room);
            return Created($"/Rooms/Get/{createdRoom.Id}", createdRoom);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Rooms>> UpdateRoomDetails(int id, [FromBody] RoomUpdateModel model)
        {
            Rooms? room = await roomService.GetRoomByIdAsync(id);
            if(room is null)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    ErrorMessage = $"No room with id {id} found!"
                });
            }

            room.UpdateRoomDetailsAsync(model.RoomName, model.RoomBuildingImg, model.RoomSiteImg, model.RoomTitle, model.RoomImg, model.RoomEquipImg, model.FloorId);
            await roomService.UpdateRoomByIdAsync(room);

            return Ok(room);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteRoomById(int id)
        {
            var result = await roomService.DeleteRoomByIdAsync(id);
            if(!result)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    ErrorMessage = $"No room with id {id} found!"
                });
            }

            return Ok(new { Message = $"Room with id {id} has been successfully deleted!" });
        }
    }
}
