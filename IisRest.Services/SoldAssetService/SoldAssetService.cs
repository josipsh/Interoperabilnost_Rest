using IisRest.Contracts.Entities;
using IisRest.Contracts.Repositories;
using IisRest.Contracts.Services;

namespace IisRest.Services.SoldAssetService
{
    public class SoldAssetService : ISoldAssetService
    {
        private readonly IUnitOfWork _uow;

        public SoldAssetService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public IEnumerable<SoldAsset> GetAll()
        {
            return _uow.SoldAssetRepository.GetAll();
        }

        public SoldAsset GetById(int id)
        {
            SoldAsset? soldAsset = _uow.SoldAssetRepository.GetById(id);
            if (soldAsset != null)
            {
                return soldAsset;
            }

            throw new Exception($"No record with id {id}");
        }

        public void Create(SoldAsset soldAsset)
        {
            if (soldAsset == null)
            {
                throw new ArgumentNullException(nameof(soldAsset));
            }

            _uow.SoldAssetRepository.Create(soldAsset);

            _uow.SaveChanges();
        }

    }
}
