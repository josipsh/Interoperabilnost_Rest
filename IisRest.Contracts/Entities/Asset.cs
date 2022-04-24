namespace IisRest.Contracts.Entities
{
    public class Asset : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Symbol { get; set; } = default!;
        public AssetType AssetType { get; set; } = default!;

        public List<Price> Prices { get; set; } = default!;
        public List<BoughtAsset> BoghtAssets { get; set; } = default!;
        public List<SoldAsset> SoldAssets { get; set; } = default!;
    }
}
