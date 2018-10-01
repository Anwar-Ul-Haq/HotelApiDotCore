using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Models;
using HotelApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Controllers
{
    [ApiController]

    [Route("/[controller]")]
    public class RoomsController:ControllerBase
    {
        private readonly IRoomService _roomService;


        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

      
        [HttpGet(Name = nameof(GetAllRooms))]
        [ProducesResponseType(200)]

        public async Task<ActionResult<Collection<Room>>> GetAllRooms()
        {
            var rooms = await _roomService.GetRoomsAsync();
            var collection = new Collection<Room>
            {

                Self = Link.ToCollection(nameof(GetAllRooms)),
                Value = rooms.ToArray()

            };

            return collection;
        }

        //Get rooms/{roomId}

        [HttpGet("{roomId}", Name = nameof(GetRoomById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]

        public async Task<ActionResult<Room>> GetRoomById(Guid roomId)
        {
            var room = await _roomService.GetRoomAsync(roomId);

            if (room == null) return NotFound();

            return room;


        }

    }
}
