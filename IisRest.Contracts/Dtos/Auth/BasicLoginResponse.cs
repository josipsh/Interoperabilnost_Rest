namespace IisRest.Contracts.Dtos.Auth
{
    public class BasicLoginResponse
    {
        public string Token { get; set; } = default!;
        public DateTime ExpireAt { get; set; } = default!;
    }
}
