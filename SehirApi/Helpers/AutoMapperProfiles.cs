using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityForListDto>()
                .ForMember(destination=> destination.PhotoUrl, opt =>
                {
                    //ismi otomatik eşleşmeyen için
                    opt.MapFrom(source=> source.Photos.FirstOrDefault(p=>p.IsMain).Url);
                });
            CreateMap<City, CityForDetailDto>().ReverseMap();
            CreateMap<Photo, PhotoForCreationDto>().ReverseMap();
            CreateMap<Photo, PhotoForReturnDto>().ReverseMap();
        }
    }
}
