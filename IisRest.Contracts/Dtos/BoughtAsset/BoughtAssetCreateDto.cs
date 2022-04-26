using IisRest.Contracts.Dtos.Asset;
using IisRest.Contracts.Dtos.Price;

namespace IisRest.Contracts.Dtos.BoughtAsset
{
    public class BoughtAssetCreateDto
    {
        public DateTime BuyDate { get; set; }
        public double Amount { get; set; }
        public PriceCreateDto Price { get; set; } = default!;
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
