using System.Runtime.Serialization;

namespace IisRest.Contracts.Dtos.Auth
{
    [DataContract]
    public class BasicLoginRequest
    {
        [DataMember(Order = 0)]
        public string Email { get; set; } = default!;

        [DataMember(Order = 1)]
        public string Password { get; set; } = default!;
    }
}
