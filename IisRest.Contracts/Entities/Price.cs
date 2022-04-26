using IisRest.Contracts.Dtos.Price;

namespace IisRest.Contracts.Entities
{
    public class Price : BaseEntity
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public double PriceRate { get; set; }
        public DateTime PriceDate { get; set; }

        public AssetPrice AssetPrice { get; set; } = default!;
        public Currency Currency { get; set; } = default!;

        internal PriceReadDto ToReadDto()
        {
            return new PriceReadDto()
            {
                Id = Id,
                Currency = Currency.ToReadDto(),
                PriceRate = PriceRate,
                PriceDate = PriceDate,
            };
        }
    }
}
