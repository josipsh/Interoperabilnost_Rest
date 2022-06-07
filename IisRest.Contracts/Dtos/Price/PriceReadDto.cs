using System.Runtime.Serialization;
using IisRest.Contracts.Dtos.Currency;

namespace IisRest.Contracts.Dtos.Price
{
    [DataContract]
    public class PriceReadDto
    {
        [DataMember(Order = 0)]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        public CurrencyReadDto Currency { get; set; } = default!;

        [DataMember(Order = 2)]
        public double PriceRate { get; set; }

        [DataMember(Order = 3)]
        public DateTime PriceDate { get; set; }
    }
}
