using AutoMapper;
using IisRest.Contracts.Dtos.SoldAsset;
using IisRest.Contracts.Entities;

namespace IisRest.API.Profiles
{
    public class SoldAssetProfiles : Profile
    {
        public SoldAssetProfiles()
        {
            // source->target
            CreateMap<SoldAsset, SoldAssetReadDto>();
            CreateMap<SoldAssetCreateDto, SoldAsset>();
        }
    }
}
