using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;

namespace HotelApi.Controllers
{
    [Route("/")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RootController:ControllerBase
    {

        [HttpGet(Name = nameof(GetRoot))]
        [ProducesResponseType(200)]
        public IActionResult GetRoot()
        {

            var response = new
            {

                href = Url.Link(nameof(GetRoot) ,null),
                rooms = new { href = Url.Link(nameof(RoomsController.GetRooms) , null) 
            }

            };

            return Ok(response);
        }
    }
}
