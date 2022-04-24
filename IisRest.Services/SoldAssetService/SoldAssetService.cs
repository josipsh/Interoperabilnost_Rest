using AutoMapper;
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

        public IEnumerable<SoldAssetReadDto> GetAll()
        {
            return _uow.SoldAssetRepository.GetAll().Select(x => x.ToReadDto());
        }

        public SoldAssetReadDto GetById(int id)
        {
            SoldAsset? soldAsset = _uow.SoldAssetRepository.GetById(id);
            if (soldAsset != null)
            {
                return soldAsset.ToReadDto();
            }

            throw new Exception($"No record with id {id}");
        }

        public SoldAssetReadDto Create(SoldAssetCreateDto soldAsset)
        {
            if (soldAsset == null)
            {
                throw new ArgumentNullException(nameof(soldAsset));
            }

            SoldAsset soldAssetModel = soldAsset.ToModel();
            Price price = soldAsset.Price.ToModel();

            soldAssetModel.ProfileId = 12;

            _uow.SoldAssetRepository.Create(soldAssetModel);
            _uow.SaveChanges();

            price.AssetId = soldAssetModel.AssetId;
            _uow.PriceRepository.Create(price);
            _uow.SaveChanges();

            return soldAssetModel.ToReadDto();
        }
    }
}
