using IisRest.Contracts.Dtos.BoughtAsset;

namespace IisRest.Contracts.Services
{
    public interface IBoughtAssetService
    {
        IEnumerable<BoughtAssetReadDto> GetAll(int userId);
        BoughtAssetReadDto GetById(int userId, int id);
        BoughtAssetReadDto Create(int userId, BoughtAssetCreateDto boughtAsset);
    }
}
