namespace IisRest.Contracts.Entities
{
    public class Price : BaseEntity
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public int CurrencyId { get; set; }
        public double PriceRate { get; set; }
        public DateTime PriceDate { get; set; }

        public Asset Asset { get; set; } = default!;
        public Currency Currency { get; set; } = default!;
        public List<BoughtAsset> BoghtAssets { get; set; } = default!;
        // public List<SoldAsset> SoldAssets { get; set; } = default!;
    }
}
