namespace IisRest.Contracts.Entities
{
    public class SoldAsset : BaseEntity
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int AssetId { get; set; }
        // public int PriceId { get; set; }
        public DateTime SellDate { get; set; }
        public double Amount { get; set; }

        public Profile Profile { get; set; } = default!;
        // public Price Price { get; set; } = default!;
        public Asset Asset { get; set; } = default!;
    }
}
