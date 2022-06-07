using System.Runtime.Serialization;
using IisRest.Contracts.Entities;

namespace IisRest.Contracts.Dtos.Auth
{
    [DataContract]
    public class BasicRegisterRequest
    {
        [DataMember(Order = 0)]
        public string UserName { get; set; } = default!;

        [DataMember(Order = 1)]
        public string FirstName { get; set; } = default!;

        [DataMember(Order = 2)]
        public string MiddleName { get; set; } = default!;

        [DataMember(Order = 3)]
        public string LastName { get; set; } = default!;

        [DataMember(Order = 4)]
        public string Email { get; set; } = default!;

        [DataMember(Order = 5)]
        public string Password { get; set; } = default!;

        [DataMember(Order = 6)]
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
