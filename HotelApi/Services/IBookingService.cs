using System;
using System.Threading.Tasks;
using HotelApi.Models;

namespace HotelApi.Services
{
    public interface IBookingService
    {
        Task<Booking> GetBookingAsync(Guid bookingId);

        Task<Guid> CreateBookingAsync(
            Guid userId,
            Guid roomId,
            DateTimeOffset startAt,
            DateTimeOffset endAt);
    }

}
