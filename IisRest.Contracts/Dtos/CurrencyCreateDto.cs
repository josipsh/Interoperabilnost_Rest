namespace IisRest.Contracts.Dtos
{
    public class CurrencyCreateDto
    {
        public string Name { get; set; } = default!;
        public string Symbol { get; set; } = default!;
    }
}
