using AutoMapper;
using IisRest.Contracts.Dtos;

namespace IisRest.API.Profiles
{
    internal class AssetProfile : Profile
    {
        public AssetProfile()
        {
            // source->target
            CreateMap<Contracts.Entities.Asset, AssetReadDto>();
            CreateMap<AssetCreateDto, Contracts.Entities.Asset>();
        }
    }
}
