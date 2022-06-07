using System.Runtime.Serialization;
using IisRest.Contracts.Dtos.Asset;
using IisRest.Contracts.Dtos.Price;

namespace IisRest.Contracts.Dtos.SoldAsset
{
    [DataContract]
    public class SoldAssetReadDto
    {
        [DataMember(Order = 0)]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        public DateTime SellDate { get; set; }

        [DataMember(Order = 2)]
        public double Amount { get; set; }

        [DataMember(Order = 3)]
        public PriceReadDto Price { get; set; } = default!;

        [DataMember(Order = 4)]
        public AssetReadDto Asset { get; set; } = default!;
    }
}
