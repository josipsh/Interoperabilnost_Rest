using System.Runtime.Serialization;

namespace IisRest.Contracts.Dtos.Currency
{
    [DataContract]
    public class CurrencyReadDto
    {
        [DataMember(Order = 0)]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        public string Name { get; set; } = default!;

        [DataMember(Order = 2)]
        public string Symbol { get; set; } = default!;
    }
}
