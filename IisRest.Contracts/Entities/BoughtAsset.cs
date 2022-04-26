namespace IisRest.Contracts.Entities
{
    public class BoughtAsset : BaseEntity
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int AssetPriceId { get; set; }
        public DateTime BuyDate { get; set; }
        public double Amount { get; set; }

        public UserProfile Profile { get; set; } = default!;
        public AssetPrice AssetPrice { get; set; } = default!;
    }
}
