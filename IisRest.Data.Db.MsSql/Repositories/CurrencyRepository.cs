using IisRest.Contracts.Entities;
using IisRest.Contracts.Repositories;
using IisRest.Data.Db.MsSql.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IisRest.Data.Db.MsSql.Repositories
{
    internal class CurrencyRepository : Repository<Currency>, ICurrencyRepository
    {
        private readonly ApplicationDbContext _context;

        public CurrencyRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Currency? GetCurrencyBySymbol(string symbol)
        {
            return _context.Currencies.FirstOrDefault(c => c.Symbol == symbol);
        }
    }
}
