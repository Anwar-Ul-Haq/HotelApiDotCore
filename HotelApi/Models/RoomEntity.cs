using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApi.Models
{
    public class RoomEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; } // prices store as int .Devide by hundred when you get back

    }
}
