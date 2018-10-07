using System;
using System.Threading.Tasks;
using HotelApi.Models;
using HotelApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // TODO: authorization
        [HttpGet("{bookingId}", Name = nameof(GetBookingById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Booking>> GetBookingById(Guid bookingId)
        {
            var booking = await _bookingService.GetBookingAsync(bookingId);
            if (booking == null) return NotFound();

            return booking;
        }
    }

}
