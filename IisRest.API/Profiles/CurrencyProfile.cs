using AutoMapper;
using IisRest.Contracts.Dtos.Currency;

namespace IisRest.API.Profiles
{
    internal class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            CreateMap<Contracts.Entities.Currency, CurrencyReadDto>();
            CreateMap<CurrencyCreateDto, Contracts.Entities.Currency>();
        }
    }
}
