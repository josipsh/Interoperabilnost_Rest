using System.Runtime.Serialization;
using IisRest.Contracts.Dtos.Currency;

namespace IisRest.Contracts.Dtos.Price
{
    [DataContract]
    public class PriceReadDto
    {
        [DataMember(Order = 0, Name = "Id")]
        public int Id { get; set; }

        [DataMember(Order = 1, Name = "Currency")]
        public CurrencyReadDto Currency { get; set; } = default!;

        [DataMember(Order = 2, Name = "PriceRate")]
        public double PriceRate { get; set; }

        [DataMember(Order = 3, Name = "PriceDate")]
        public DateTime PriceDate { get; set; }
    }
}
