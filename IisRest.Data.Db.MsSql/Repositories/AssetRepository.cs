using IisRest.Contracts.Entities;
using IisRest.Contracts.Repositories;
using IisRest.Data.Db.MsSql.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IisRest.Data.Db.MsSql.Repositories
{
    internal class AssetRepository : Repository<Asset>, IAssetRepository
    {
        private readonly ApplicationDbContext _context;

        public AssetRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<Asset> GetAll()
        {
            return _context.Assets
                .Include(x => x.AssetPrices)
                .ToList();
        }

        public override Asset? GetById(int id)
        {
            return _context.Assets
                .Include(x => x.AssetPrices)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
