using IisRest.Contracts.Entities;

namespace IisRest.Contracts.Repositories
{
    public interface ICurrencyRepository : IRepository<Currency>
    {
        Currency? GetCurrencyBySymbol(string symbol);
    }
}
