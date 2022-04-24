namespace IisRest.Contracts.Dtos.Currency
{
    public class CurrencyReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Symbol { get; set; } = default!;
    }
}
