using System.Runtime.Serialization;

namespace IisRest.Contracts.Dtos.Auth
{
    [DataContract]
    public class BasicRegisterResponse
    {
        [DataMember(Order = 0)]
        public string Token { get; set; } = default!;

        [DataMember(Order = 1)]
        public DateTime ExpireAt { get; set; } = default!;

        [DataMember(Order = 2)]
        public string UserName { get; set; } = default!;

        [DataMember(Order = 3)]
        public string FirstName { get; set; } = default!;

        [DataMember(Order = 4)]
        public string MiddleName { get; set; } = default!;

        [DataMember(Order = 5)]
        public string LastName { get; set; } = default!;

        [DataMember(Order = 6)]
        public string Email { get; set; } = default!;
    }
}
