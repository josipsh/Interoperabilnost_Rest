using IisRest.Contracts.Entities;
using IisRest.Contracts.Repositories;
using IisRest.Contracts.Services;

namespace IisRest.Services.BoughtAssetService
{
    public class BoughtAssetService : IBoughtAssetService
    {
        private readonly IUnitOfWork _uow;

        public BoughtAssetService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public IEnumerable<BoughtAsset> GetAll()
        {
            return _uow.BoughtAssetRepository.GetAll();
        }

        public BoughtAsset GetById(int id)
        {
            BoughtAsset? boughtAsset = _uow.BoughtAssetRepository.GetById(id);

            if (boughtAsset != null)
            {
                return boughtAsset;
            }

            throw new Exception($"No record with id {id}");
        }

        public void Create(BoughtAsset boughtAsset)
        {
            if (boughtAsset == null)
            {
                throw new ArgumentNullException(nameof(boughtAsset));
            }

            _uow.BoughtAssetRepository.Create(boughtAsset);
        }

    }
}
