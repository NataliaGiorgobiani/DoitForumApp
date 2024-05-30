using AutoMapper;
using Forum.Entities;
using Forum.Models;
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
            });
            return configuration.CreateMapper();
        }
    }
}
