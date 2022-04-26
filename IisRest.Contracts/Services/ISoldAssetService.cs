using IisRest.Contracts.Dtos.SoldAsset;

namespace IisRest.Contracts.Services
{
    public interface ISoldAssetService
    {
        IEnumerable<SoldAssetReadDto> GetAll(int userId);
        SoldAssetReadDto GetById(int userId, int id);
        SoldAssetReadDto Create(int userId, SoldAssetCreateDto soldAsset);
    }
}
