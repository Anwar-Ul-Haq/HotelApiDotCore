using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using HotelApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApi
{
    public class HotelApiDbContext:DbContext
    {
        public HotelApiDbContext(DbContextOptions options) :base(options) { }


        public DbSet<RoomEntity> Rooms { get; set; }

        

           
            
        
    }
}
