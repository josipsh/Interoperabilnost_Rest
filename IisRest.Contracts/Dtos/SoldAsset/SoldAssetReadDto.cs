using IisRest.Contracts.Dtos.Asset;
using IisRest.Contracts.Dtos.Price;

namespace IisRest.Contracts.Dtos.SoldAsset
{
    public class SoldAssetReadDto
    {
        public int Id { get; set; }
        public DateTime SellDate { get; set; }
        public double Amount { get; set; }
        public PriceReadDto Price { get; set; } = default!;
        public AssetReadDto Asset { get; set; } = default!;
    }
}
