using IisRest.Contracts.Entities;
using IisRest.Contracts.Repositories;
using IisRest.Data.Db.MsSql.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IisRest.Data.Db.MsSql.Repositories
{
    internal class BoughtAssetRepository : Repository<BoughtAsset>, IBoughtAssetRepository
    {
        private readonly ApplicationDbContext _context;

        public BoughtAssetRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<BoughtAsset> GetAll()
        {
            return _context.BoughtAssets
                .Include(b => b.Profile)
                .Include(b => b.AssetPrice)
                .ThenInclude(p => p.Price)
                .ThenInclude(c => c.Currency)
                .Include(b => b.AssetPrice)
                .ThenInclude(p => p.Asset)
                .ToList();
        }

        public override BoughtAsset? GetById(int id)
        {
            return _context.BoughtAssets
                .Include(b => b.Profile)
                .Include(b => b.AssetPrice)
                .ThenInclude(p => p.Price)
                .ThenInclude(c => c.Currency)
                .Include(b => b.AssetPrice)
                .ThenInclude(p => p.Asset)
                .FirstOrDefault(a => a.Id == id);
        }
    }
}
