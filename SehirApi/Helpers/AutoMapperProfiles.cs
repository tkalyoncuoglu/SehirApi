using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SehirApi.Dtos.Request;
using SehirApi.Models;
using SehirApi.Dtos.Response;

namespace SehirRehberi.API.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Photo, SehirApi.Dtos.Response.PhotoDto>();
            CreateMap<City, CityDetailDto>().ReverseMap();
            CreateMap<SehirApi.Dtos.Request.PhotoDto, Photo>().
                ForMember(destination => destination.File, opt => opt.Ignore()); ;
            CreateMap<CityDto, City>().ReverseMap();
        }
    }
}
