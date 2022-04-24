namespace IisRest.Contracts.Dtos.Auth
{
    public class BasicLoginRequest
    {
        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;
    }
}
