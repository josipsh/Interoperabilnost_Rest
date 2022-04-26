using IisRest.Contracts.Dtos.SoldAsset;
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

        public IEnumerable<SoldAssetReadDto> GetAll(int userId)
        {
            return _uow.SoldAssetRepository
                .GetAll()
                .Where(x => x.ProfileId == userId)
                .Select(x => x.ToReadDto());
        }

        public SoldAssetReadDto GetById(int userId, int id)
        {
            SoldAsset? soldAsset = _uow.SoldAssetRepository.GetById(id);
            if (soldAsset == null)
            {
                throw new Exception($"No record with id {id}");
            }

            if (soldAsset.ProfileId != userId)
            {
                throw new Exception($"Unexpected error occured. We are working on it");
            }

            return soldAsset.ToReadDto();
        }

        public SoldAssetReadDto Create(int userId, SoldAssetCreateDto soldAsset)
        {
            if (soldAsset == null)
            {
                throw new ArgumentNullException(nameof(soldAsset));
            }

            SoldAsset soldAssetModel = soldAsset.ToModel();

            soldAssetModel.ProfileId = userId;
            _uow.PriceRepository.Create(soldAssetModel.AssetPrice.Price);
            _uow.AssetRepository.Create(soldAssetModel.AssetPrice.Asset);
            _uow.SoldAssetRepository.Create(soldAssetModel);
            _uow.SaveChanges();

            return soldAssetModel.ToReadDto();
        }
    }
}
