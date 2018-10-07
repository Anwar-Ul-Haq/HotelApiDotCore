using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelApi.Models;
using LandonApi.Models;

namespace HotelApi.Services
{
    public interface IOpeningService
    {
        Task<PagedResults<Opening>> GetOpeningsAsync(PagingOptions pagingOptions);

        Task<IEnumerable<BookingRange>> GetConflictingSlots(
            Guid roomId,
            DateTimeOffset start,
            DateTimeOffset end);
    }
}
