using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzaboGlass.Data.Dtos;
using SzaboGlass.Data.Entity;

namespace SzaboGlass.Logic.Config.MapperConfigurations
{
    internal class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<GlassType, GlassTypeDto>();

            CreateMap<Glass, GlassDto>()
            .ForMember(dest => dest.PriceWithVAT, opt => opt.Ignore())
            .ForMember(dest => dest.UniquePrice, opt => opt.Ignore())
            .ForMember(dest => dest.SerialPrice, opt => opt.Ignore());

            CreateMap<GlassCreationDto, Glass>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.GlassType, opt => opt.Ignore())
                .ForMember(dest => dest.GlassTypeId, opt => opt.Ignore());
        }
    }
}
