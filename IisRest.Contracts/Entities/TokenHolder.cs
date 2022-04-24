namespace IisRest.Contracts.Entities
{
    public class TokenHolder
    {
        public string Token { get; set; } = default!;
        public DateTime ExpiresAt { get; set; } = default!;
    }
}
