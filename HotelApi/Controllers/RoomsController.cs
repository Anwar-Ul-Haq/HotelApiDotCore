﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [ApiController]

    [Route("/[controller]")]
    public class RoomsController:ControllerBase
    {
        [HttpGet(Name = nameof(GetRooms))]

        public IActionResult GetRooms()
        {
            throw new NotImplementedException();
        }
    }
}