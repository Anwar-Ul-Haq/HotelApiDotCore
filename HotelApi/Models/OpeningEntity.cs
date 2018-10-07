using System;

namespace HotelApi.Models
{
    public class OpeningEntity : BookingRange
    {
        public Guid RoomId { get; set; }

        public int Rate { get; set; }
    }
}
