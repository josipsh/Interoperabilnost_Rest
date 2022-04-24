using IisRest.Contracts.Dtos.Currency;

namespace IisRest.Contracts.Dtos.Price
{
    public class PriceReadDto
    {
        public int Id { get; set; }
        public CurrencyReadDto Currency { get; set; } = default!;
        public double PriceRate { get; set; }
        public DateTime PriceDate { get; set; }
    }
}
