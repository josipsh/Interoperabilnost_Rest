namespace IisRest.Contracts.Dtos
{
    public class BasicRegisterResponse
    {
        public string Token { get; set; } = default!;
        public DateTime ExpireAt { get; set; } = default!;

        public string UserName { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string MiddleName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
