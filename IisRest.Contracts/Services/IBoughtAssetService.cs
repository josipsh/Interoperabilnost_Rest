using IisRest.Contracts.Entities;

namespace IisRest.Contracts.Services
{
    public interface IBoughtAssetService
    {
        IEnumerable<BoughtAsset> GetAll();
        BoughtAsset GetById(int id);
        void Create(BoughtAsset boughtAsset);
    }
}
