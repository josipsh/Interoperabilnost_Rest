using IisRest.Contracts.Dtos.Asset;
using IisRest.Contracts.Dtos.Price;

namespace IisRest.Contracts.Dtos.BoughtAsset
{
    public class BoughtAssetReadDto
    {
        public int Id { get; set; }
        public DateTime BuyDate { get; set; }
        public double Amount { get; set; }
        public PriceReadDto Price { get; set; } = default!;
        public AssetReadDto Asset { get; set; } = default!;
    }
}
