using HotelApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApi.Services
{
   public  interface IRoomService
   {
       Task<Room> GetRoomAsync(Guid Id);

   }
}
