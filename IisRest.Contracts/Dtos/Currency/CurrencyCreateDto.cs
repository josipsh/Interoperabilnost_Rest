using System.Runtime.Serialization;

namespace IisRest.Contracts.Dtos.Currency
{
    [DataContract]
    public class CurrencyCreateDto
    {
        [DataMember(Order = 0)]
        public string Name { get; set; } = default!;

        [DataMember(Order = 1)]
        public string Symbol { get; set; } = default!;

        public Entities.Currency ToModel()
        {
            return new Entities.Currency()
            {
                Name = Name,
                Symbol = Symbol,
            };
        }
    }
}
