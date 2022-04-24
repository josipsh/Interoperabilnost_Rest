namespace IisRest.Contracts.Dtos
{
    public class BasicLoginRequest
    {
        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;
    }
}
