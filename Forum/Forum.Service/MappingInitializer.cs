using AutoMapper;
using Forum.Entities;
using Forum.Models;
using Forum.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service
{
    public static class MappingInitializer
    {
        public static IMapper Initialize() 
        {
            MapperConfiguration configuration = new(config =>
            {
                config.CreateMap<ForumEntity, ForumForAddingDto>().ReverseMap();
                config.CreateMap<ForumEntity, ForumForGettingDto>().ReverseMap();
                config.CreateMap<ForumEntity, ForumForUpdatingDto>().ReverseMap();
                config.CreateMap<UserDto, IdentityUser>().ReverseMap();
                config.CreateMap<RegistrationRequestDto, IdentityUser>()
                .ForMember(destination => destination.UserName, options => options.MapFrom(source => source.Email))
                .ForMember(destination => destination.NormalizedUserName, options => options.MapFrom(source => source.Email.ToUpper()))
                .ForMember(destination => destination.Email, options => options.MapFrom(source => source.Email))
                .ForMember(destination => destination.NormalizedEmail, options => options.MapFrom(source => source.Email.ToUpper()));
            });
            return configuration.CreateMapper();
        }
    }
}
