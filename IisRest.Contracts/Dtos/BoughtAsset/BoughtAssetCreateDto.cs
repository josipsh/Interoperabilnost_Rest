using System.Runtime.Serialization;
using IisRest.Contracts.Dtos.Asset;
using IisRest.Contracts.Dtos.Price;

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
        public PriceCreateDto Price { get; set; } = default!;

        [DataMember(Order = 3)]
        public AssetCreateDto Asset { get; set; } = default!;

        public Entities.BoughtAsset ToModel()
        {
            return new Entities.BoughtAsset()
            {
                BuyDate = BuyDate,
                Amount = Amount,
                AssetPrice = new Entities.AssetPrice()
                {
                    Asset = Asset.ToModel(),
                    Price = Price.ToModel(),
                },
            };
        }
    }
}
