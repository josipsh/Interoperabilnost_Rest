using IisRest.Contracts.Dtos.Currency;

namespace IisRest.Contracts.Dtos.Price
{
    public class PriceCreateDto
    {
        public CurrencyCreateDto Currency { get; set; } = default!;
        public double PriceRate { get; set; }
        public DateTime PriceDate { get; set; }
    }
}
