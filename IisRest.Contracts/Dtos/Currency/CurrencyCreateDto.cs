namespace IisRest.Contracts.Dtos.Currency
{
    public class CurrencyCreateDto
    {
        public string Name { get; set; } = default!;
        public string Symbol { get; set; } = default!;
    }
}