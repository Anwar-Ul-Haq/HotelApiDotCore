using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApi.Models;

namespace HotelApi.Infrastructure
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomEntity, Room>().ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate / 100.0m));

            //todo  Url.Link here
        }
    }
}
