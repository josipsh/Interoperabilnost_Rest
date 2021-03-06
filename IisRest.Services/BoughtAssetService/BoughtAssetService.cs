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

        public BoughtAssetReadDto Create(int userId, BoughtAssetCreateDto boughtAsset)
        {
            if (boughtAsset == null)
            {
                throw new ArgumentNullException(nameof(boughtAsset));
            }

            Price price = new Price()
            {
                PriceRate = boughtAsset.PriceRate,
                CurrencyId = boughtAsset.CurrencyId,
                PriceDate = boughtAsset.PriceDate,
            };

            _uow.PriceRepository.Create(price);
            _uow.SaveChanges();

            BoughtAsset boughtAssetModel = boughtAsset.ToModel();
            boughtAssetModel.ProfileId = userId;
            boughtAssetModel.PriceId = price.Id;

            _uow.BoughtAssetRepository.Create(boughtAssetModel);
            _uow.SaveChanges();

            return boughtAssetModel.ToReadDto();
        }
    }
}
