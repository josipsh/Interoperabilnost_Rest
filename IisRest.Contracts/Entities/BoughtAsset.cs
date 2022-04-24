namespace IisRest.Contracts.Entities
{
    public class BoughtAsset : BaseEntity
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int AssetId { get; set; }
        public DateTime BuyDate { get; set; }
        public double Amount { get; set; }

        public UserProfile Profile { get; set; } = default!;
        public Asset Asset { get; set; } = default!;
    }
}
