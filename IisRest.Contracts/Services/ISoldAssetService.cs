using IisRest.Contracts.Dtos.SoldAsset;

namespace IisRest.Contracts.Services
{
    public interface ISoldAssetService
    {
        IEnumerable<SoldAssetReadDto> GetAll();
        SoldAssetReadDto GetById(int id);
        SoldAssetReadDto Create(SoldAssetCreateDto soldAsset);
    }
}
