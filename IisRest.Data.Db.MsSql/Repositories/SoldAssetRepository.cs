using IisRest.Contracts.Entities;
using IisRest.Contracts.Repositories;
using IisRest.Data.Db.MsSql.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IisRest.Data.Db.MsSql.Repositories
{
    internal class SoldAssetRepository : Repository<SoldAsset>, ISoldAssetRepository
    {
        private readonly ApplicationDbContext _context;

        public SoldAssetRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<SoldAsset> GetAll()
        {
            return _context.SoldAssets
                .Include(s => s.Asset)
                // .Include(s => s.Price)
                .Include(s => s.Profile)
                .ToList();
        }

        public override SoldAsset? GetById(int id)
        {

            return _context.SoldAssets
                .Include(s => s.Asset)
                // .Include(s => s.Price)
                .Include(s => s.Profile)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
