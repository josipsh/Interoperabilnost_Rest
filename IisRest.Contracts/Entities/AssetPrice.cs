namespace IisRest.Contracts.Entities
{
    public class AssetPrice : BaseEntity
    {
        public int Id { get; set; }
        public int PriceId { get; set; }
        public int AssetId { get; set; }

        public Asset Asset { get; set; } = default!;
        public Price Price { get; set; } = default!;
        public List<BoughtAsset> BoughtAssets { get; set; } = default!;
        public List<SoldAsset> SoldAssets { get; set; } = default!;
    }
}
