using IisRest.Contracts.Dtos.Currency;

namespace IisRest.Contracts.Entities
{
    public class Currency : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Symbol { get; set; } = default!;

        public List<Price> Prices { get; set; } = default!;

        public CurrencyReadDto ToReadDto()
        {
            return new CurrencyReadDto()
            {
                Id = Id,
                Name = Name,
                Symbol = Symbol,
            };
        }
    }
}
