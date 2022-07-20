using IisRest.Contracts.Dtos.BoughtAsset;

namespace IisRest.Contracts.Entities
{
    public class BoughtAsset : BaseEntity
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int PriceId { get; set; }
        public int AssetId { get; set; }
        public DateTime BuyDate { get; set; }
        public double Amount { get; set; }

        public UserProfile Profile { get; set; } = default!;
        public Price Price { get; set; } = default!;
        public Asset Asset { get; set; } = default!;

        public BoughtAssetReadDto ToReadDto()
        {
            return new BoughtAssetReadDto()
            {
                Id = Id,
                Amount = Amount,
                BuyDate = BuyDate,
                Price = Price.ToReadDto(),
                Asset = Asset.ToReadDto(),
            };
        }
    }
}
