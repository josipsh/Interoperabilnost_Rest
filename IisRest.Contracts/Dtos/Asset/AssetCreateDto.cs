using IisRest.Contracts.Entities;

namespace IisRest.Contracts.Dtos.Asset
{
    public class AssetCreateDto
    {
        public string Name { get; set; } = default!;
        public string Symbol { get; set; } = default!;
        public AssetType AssetType { get; set; } = default!;
    }
}
