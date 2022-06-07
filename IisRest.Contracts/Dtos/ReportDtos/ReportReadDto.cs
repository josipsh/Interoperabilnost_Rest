using System.Runtime.Serialization;
using IisRest.Contracts.Dtos.Asset;
using IisRest.Contracts.Dtos.BoughtAsset;
using IisRest.Contracts.Dtos.Price;
using IisRest.Contracts.Dtos.SoldAsset;

namespace IisRest.Contracts.Dtos.ReportDtos
{
    [DataContract]
    public class ReportReadDto
    {
        [DataMember(Order = 0)]
        public AssetReadDto Asset { get; set; } = default!;

        [DataMember(Order = 1)]
        public PriceReadDto CurrentPrice { get; set; } = default!;

        [DataMember(Order = 2)]
        public List<BoughtAssetReadDto> BoughtAssets { get; set; } = default!;

        [DataMember(Order = 3)]
        public List<SoldAssetReadDto> SoldAsstes { get; set; } = default!;

    }
}
