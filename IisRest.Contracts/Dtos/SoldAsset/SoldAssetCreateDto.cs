using IisRest.Contracts.Dtos.Asset;
using IisRest.Contracts.Dtos.Price;

namespace IisRest.Contracts.Dtos.SoldAsset
{
    public class SoldAssetCreateDto
    {
        public DateTime SellDate { get; set; }
        public double Amount { get; set; }
        public PriceCreateDto Price { get; set; } = default!;
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
