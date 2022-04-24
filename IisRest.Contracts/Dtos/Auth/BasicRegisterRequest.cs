using IisRest.Contracts.Entities;

namespace IisRest.Contracts.Dtos.Auth
{
    public class BasicRegisterRequest
    {
        public string UserName { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string MiddleName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;
        public string PasswordConfirm { get; set; } = default!;

        public UserProfile ToModel()
        {
            return new UserProfile()
            {
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                UserName = UserName,
                Email = Email,
            };
        }

        public bool IsPasswordEqual()
        {
            return Password == PasswordConfirm;
        }
    }
}
