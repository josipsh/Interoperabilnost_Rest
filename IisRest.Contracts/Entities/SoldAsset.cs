using IisRest.Contracts.Dtos.Price;
using IisRest.Contracts.Dtos.SoldAsset;

namespace IisRest.Contracts.Entities
{
    public class SoldAsset : BaseEntity
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int AssetId { get; set; }
        public DateTime SellDate { get; set; }
        public double Amount { get; set; }

        public UserProfile Profile { get; set; } = default!;
        public Asset Asset { get; set; } = default!;

        public SoldAssetReadDto ToReadDto()
        {
            return new SoldAssetReadDto()
            {
                Id = Id,
                Amount = Amount,
                Asset = Asset.ToReadDto(),
                SellDate = SellDate,
                Price = GetPrice(),
            };
        }

        private PriceReadDto GetPrice()
        {
            Price? price = Asset.Prices.FirstOrDefault(x => x.PriceDate == SellDate);

            if (price != null)
            {
                return new PriceReadDto()
                {
                    Id = price.Id,
                    PriceDate = price.PriceDate,
                    PriceRate = price.PriceRate,
                    Currency = price.Currency.ToReadDto(),
                };
            }

            throw new Exception("Unexpected error occured, We are fetching asset price for selling date");
        }
    }
}
