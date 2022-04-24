using AutoMapper;
using IisRest.Contracts.Dtos.Price;

namespace IisRest.API.Profiles
{
    internal class PriceProfile : Profile
    {
        public PriceProfile()
        {
            // source->target
            CreateMap<Contracts.Entities.Price, PriceReadDto>();
            CreateMap<PriceCreateDto, Contracts.Entities.Price>();
        }
    }
}
