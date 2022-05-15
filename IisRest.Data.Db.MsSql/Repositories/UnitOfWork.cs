using IisRest.Contracts.Repositories;
using IisRest.Data.Db.MsSql.Configuration;

namespace IisRest.Data.Db.MsSql.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext = default!;
        private readonly IBoughtAssetRepository? _boughtAssetRepository;
        private readonly ISoldAssetRepository? _soldAssetRepository;
        private readonly IPriceRepository? _priceRepository;
        private readonly IAssetRepository? _assetRepository;
        private readonly ICurrencyRepository? _currencyRepository;

        public IBoughtAssetRepository BoughtAssetRepository => _boughtAssetRepository ?? new BoughtAssetRepository(_dbContext);
        public ISoldAssetRepository SoldAssetRepository => _soldAssetRepository ?? new SoldAssetRepository(_dbContext);
        public IPriceRepository PriceRepository => _priceRepository ?? new PriceRepository(_dbContext);
        public IAssetRepository AssetRepository => _assetRepository ?? new AssetRepository(_dbContext);
        public ICurrencyRepository CurrencyRepository => _currencyRepository ?? new CurrencyRepository(_dbContext);

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
            _boughtAssetRepository = new BoughtAssetRepository(_dbContext);
            _soldAssetRepository = new SoldAssetRepository(_dbContext);
            _priceRepository = new PriceRepository(_dbContext);
            _assetRepository = new AssetRepository(_dbContext);
            _currencyRepository = new CurrencyRepository(_dbContext);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
