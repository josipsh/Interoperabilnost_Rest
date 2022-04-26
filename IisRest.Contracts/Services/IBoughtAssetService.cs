using IisRest.Contracts.Dtos.BoughtAsset;
using IisRest.Contracts.Entities;

namespace IisRest.Contracts.Services
{
    public interface IBoughtAssetService
    {
        IEnumerable<BoughtAssetReadDto> GetAll(int userId);
        BoughtAssetReadDto GetById(int userId, int id);
        void Create(int userId, BoughtAssetCreateDto boughtAsset);
    }
}
