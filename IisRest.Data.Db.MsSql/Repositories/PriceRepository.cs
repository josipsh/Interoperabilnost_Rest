using IisRest.Contracts.Entities;
using IisRest.Contracts.Repositories;
using IisRest.Data.Db.MsSql.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IisRest.Data.Db.MsSql.Repositories
{
    internal class PriceRepository : Repository<Price>, IPriceRepository
    {
        private readonly ApplicationDbContext _context;

        public PriceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<Price> GetAll()
        {
            return _context.Prices
                .Include(x => x.Currency)
                .Include(x => x.Asset)
                .ToList();
        }

        public override Price? GetById(int id)
        {
            return _context.Prices
                .Include(x => x.Currency)
                .Include(x => x.Asset)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
