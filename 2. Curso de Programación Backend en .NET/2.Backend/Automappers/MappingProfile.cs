using _2.Backend.DTOs;
using _2.Backend.Models;
using AutoMapper;

namespace _2.Backend.Automappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BeerInsertDto, Beer>();
            CreateMap<BeerUpdateDto, Beer>();
            CreateMap<Beer, BeerDto>()
                .ForMember(dto => dto.Id,
                m => m.MapFrom(beer => beer.BeerId));
        }
    }
}
