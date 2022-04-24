using IisRest.Contracts.Entities;

namespace IisRest.Contracts.Services
{
    public interface ISoldAssetService
    {
        IEnumerable<SoldAsset> GetAll();
        SoldAsset GetById(int id);
        void Create(SoldAsset soldAsset);
    }
}
