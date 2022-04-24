using AutoMapper;
using IisRest.Contracts.Dtos;

namespace IisRest.API.Profiles
{
    public class SoldAssetProfiles : Profile
    {
        public SoldAssetProfiles()
        {
            // source->target
            CreateMap<Contracts.Entities.SoldAsset, SoldAssetReadDto>();
            CreateMap<SoldAssetCreateDto, Contracts.Entities.SoldAsset>();
        }
    }
}
