using System.Runtime.Serialization;

namespace IisRest.Contracts.Dtos.Auth
{
    [DataContract]
    public class BasicLoginResponse
    {
        [DataMember(Order = 0)]
        public string Token { get; set; } = default!;

        [DataMember(Order = 1)]
        public DateTime ExpireAt { get; set; } = default!;
    }
}
