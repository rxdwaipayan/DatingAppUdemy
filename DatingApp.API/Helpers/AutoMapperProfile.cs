using AutoMapper;
using DatingApp.API.DTO;
using DatingApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain == true).Url);
                })
                .ForMember(dest => dest.Age, opt => {
                    opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                });
            CreateMap<User, UserForDetailedDto>()
                 .ForMember(dest => dest.PhotoUrl, opt =>
                 {
                     opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain == true).Url);
                 })
                 .ForMember(dest => dest.Age, opt => {
                     opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                 });
            CreateMap<Photo, PhotosForDetailedDto>();

        }
    }
}
