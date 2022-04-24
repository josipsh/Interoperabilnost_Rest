namespace IisRest.Contracts.Dtos
{
    public class BasicLoginResponse
    {
        public string Token { get; set; } = default!;
        public DateTime ExpireAt { get; set; } = default!;
    }
}
