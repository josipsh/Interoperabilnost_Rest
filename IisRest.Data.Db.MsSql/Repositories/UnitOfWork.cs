using IisRest.Contracts.Repositories;
using IisRest.Data.Db.MsSql.Configuration;

namespace IisRest.Data.Db.MsSql.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext = default!;
        private readonly IBoughtAssetRepository? _boughtAssetRepository;
        private readonly ISoldAssetRepository? _soldAssetRepository;

        public IBoughtAssetRepository BoughtAssetRepository => _boughtAssetRepository ?? new BoughtAssetRepository(_dbContext);
        public ISoldAssetRepository SoldAssetRepository => _soldAssetRepository ?? new SoldAssetRepository(_dbContext);

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
            _boughtAssetRepository = new BoughtAssetRepository(_dbContext);
            _soldAssetRepository = new SoldAssetRepository(_dbContext);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
