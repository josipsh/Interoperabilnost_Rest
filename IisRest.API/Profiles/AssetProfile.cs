using AutoMapper;
using IisRest.Contracts.Dtos.Asset;
using IisRest.Contracts.Entities;

namespace IisRest.API.Profiles
{
    internal class AssetProfile : Profile
    {
        public AssetProfile()
        {
            // source->target
            CreateMap<Asset, AssetReadDto>();
            CreateMap<AssetCreateDto, Asset>();
        }
    }
}
