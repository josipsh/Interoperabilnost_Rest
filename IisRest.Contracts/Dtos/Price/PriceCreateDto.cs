using System.Runtime.Serialization;
using IisRest.Contracts.Dtos.Currency;

namespace IisRest.Contracts.Dtos.Price
{
    [DataContract]
    public class PriceCreateDto
    {
        [DataMember(Order = 0)]
        public CurrencyCreateDto Currency { get; set; } = default!;

        [DataMember(Order = 1)]
        public double PriceRate { get; set; }

        [DataMember(Order = 2)]
        public DateTime PriceDate { get; set; }

        public Entities.Price ToModel()
        {
            return new Entities.Price()
            {
                Currency = Currency.ToModel(),
                PriceRate = PriceRate,
                PriceDate = PriceDate,
            };
        }
    }
}
