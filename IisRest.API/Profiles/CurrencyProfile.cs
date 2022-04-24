using AutoMapper;
using IisRest.Contracts.Dtos.Currency;
using IisRest.Contracts.Entities;

namespace IisRest.API.Profiles
{
    internal class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            CreateMap<Currency, CurrencyReadDto>();
            CreateMap<CurrencyCreateDto, Currency>();
        }
    }
}
