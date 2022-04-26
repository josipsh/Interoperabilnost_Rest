using IisRest.Contracts.Dtos.SoldAsset;

namespace IisRest.Contracts.Entities
{
    public class SoldAsset : BaseEntity
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int AssetPriceId { get; set; }
        public DateTime SellDate { get; set; }
        public double Amount { get; set; }

        public UserProfile Profile { get; set; } = default!;
        public AssetPrice AssetPrice { get; set; } = default!;

        public SoldAssetReadDto ToReadDto()
        {
            return new SoldAssetReadDto()
            {
                Id = Id,
                Amount = Amount,
                SellDate = SellDate,
                Asset = AssetPrice.Asset.ToReadDto(),
                Price = AssetPrice.Price.ToReadDto(),
            };
        }
    }
}
