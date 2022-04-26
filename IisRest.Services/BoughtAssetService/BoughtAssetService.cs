using IisRest.Contracts.Dtos.BoughtAsset;
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

        public IEnumerable<BoughtAssetReadDto> GetAll(int userId)
        {
            return _uow.BoughtAssetRepository
                .GetAll()
                .Where(x => x.ProfileId == userId)
                .Select(x => x.ToReadDto());
        }

        public BoughtAssetReadDto GetById(int userId, int id)
        {
            BoughtAsset? boughtAsset = _uow.BoughtAssetRepository.GetById(id);

            if (boughtAsset == null)
            {
                throw new Exception($"No record with id {id}");
            }

            if (boughtAsset.ProfileId != userId)
            {
                throw new Exception($"Unexpected error occured. We are working on it");
            }

            return boughtAsset.ToReadDto();
        }

        public void Create(int userId, BoughtAssetCreateDto boughtAsset)
        {
            if (boughtAsset == null)
            {
                throw new ArgumentNullException(nameof(boughtAsset));
            }

            BoughtAsset boughtAssetModel = boughtAsset.ToModel();
            boughtAssetModel.ProfileId = userId;

            _uow.PriceRepository.Create(boughtAssetModel.AssetPrice.Price);
            _uow.AssetRepository.Create(boughtAssetModel.AssetPrice.Asset);
            _uow.BoughtAssetRepository.Create(boughtAssetModel);
            _uow.SaveChanges();
        }

    }
}
