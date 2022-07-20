using System.Runtime.Serialization;

namespace IisRest.Contracts.Dtos.BoughtAsset
{
    [DataContract]
    public class BoughtAssetCreateDto
    {
        [DataMember(Order = 0)]
        public DateTime BuyDate { get; set; }

        [DataMember(Order = 1)]
        public double Amount { get; set; }

        [DataMember(Order = 2)]
        public int AssetId { get; set; } = default!;

        [DataMember(Order = 3)]
        public int CurrencyId { get; set; }

        [DataMember(Order = 4)]
        public double PriceRate { get; set; }

        [DataMember(Order = 5)]
        public DateTime PriceDate { get; set; }

        public Entities.BoughtAsset ToModel()
        {
            return new Entities.BoughtAsset()
            {
                BuyDate = BuyDate,
                Amount = Amount,
                AssetId = AssetId,
            };
        }
    }
}
