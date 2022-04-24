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
        private readonly IMapper _mapper;

        public SoldAssetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<SoldAssetReadDto> GetAll()
        {
            return _mapper.Map<IEnumerable<SoldAssetReadDto>>(_uow.SoldAssetRepository.GetAll());
        }

        public SoldAssetReadDto GetById(int id)
        {
            SoldAsset? soldAsset = _uow.SoldAssetRepository.GetById(id);
            if (soldAsset != null)
            {
                return _mapper.Map<SoldAssetReadDto>(soldAsset);
            }

            throw new Exception($"No record with id {id}");
        }

        public SoldAssetReadDto Create(SoldAssetCreateDto soldAsset)
        {
            if (soldAsset == null)
            {
                throw new ArgumentNullException(nameof(soldAsset));
            }

            SoldAsset soldAssetModel = _mapper.Map<SoldAsset>(soldAsset);

            _uow.SoldAssetRepository.Create(soldAssetModel);
            _uow.SaveChanges();

            return _mapper.Map<SoldAssetReadDto>(soldAssetModel);
        }
    }
}
