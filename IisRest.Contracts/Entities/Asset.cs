using IisRest.Contracts.Dtos.Asset;

namespace IisRest.Contracts.Entities
{
    public class Asset : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Symbol { get; set; } = default!;
        public AssetType AssetType { get; set; } = default!;

        public List<AssetPrice> AssetPrices { get; set; } = default!;

        public AssetReadDto ToReadDto()
        {
            return new AssetReadDto()
            {
                Id = Id,
                Name = Name,
                Symbol = Symbol,
                AssetType = AssetType,
            };
        }
    }
}
