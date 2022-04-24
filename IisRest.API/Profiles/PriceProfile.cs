using AutoMapper;
using IisRest.Contracts.Dtos.Price;
using IisRest.Contracts.Entities;

namespace IisRest.API.Profiles
{
    internal class PriceProfile : Profile
    {
        public PriceProfile()
        {
            // source->target
            CreateMap<Price, PriceReadDto>();
            CreateMap<PriceCreateDto, Price>();
        }
    }
}
