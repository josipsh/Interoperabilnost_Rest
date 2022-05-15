using IisRest.Contracts.Dtos.Asset;
using IisRest.Contracts.Dtos.BoughtAsset;
using IisRest.Contracts.Dtos.Price;
using IisRest.Contracts.Dtos.SoldAsset;

namespace IisRest.Contracts.Dtos.ReportDtos
{
    public class ReportReadDto
    {
        public AssetReadDto Asset { get; set; } = default!;
        public PriceReadDto CurrentPrice { get; set; } = default!;
        public List<BoughtAssetReadDto> BoughtAssets { get; set; } = default!;
        public List<SoldAssetReadDto> SoldAsstes { get; set; } = default!;

    }
}
