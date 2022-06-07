using System.Runtime.Serialization;
using IisRest.Contracts.Dtos.Asset;
using IisRest.Contracts.Dtos.Price;

namespace IisRest.Contracts.Dtos.SoldAsset
{
    [DataContract]
    public class SoldAssetCreateDto
    {
        [DataMember(Order = 0)]
        public DateTime SellDate { get; set; }

        [DataMember(Order = 1)]
        public double Amount { get; set; }

        [DataMember(Order = 2)]
        public PriceCreateDto Price { get; set; } = default!;

        [DataMember(Order = 3)]
        public AssetCreateDto Asset { get; set; } = default!;

        public Entities.SoldAsset ToModel()
        {
            return new Entities.SoldAsset()
            {
                Amount = Amount,
                SellDate = SellDate,
                AssetPrice = new Entities.AssetPrice()
                {
                    Asset = Asset.ToModel(),
                    Price = Price.ToModel(),
                },
            };
        }
    }
}
