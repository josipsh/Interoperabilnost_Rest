using System.Runtime.Serialization;
using IisRest.Contracts.Dtos.Asset;
using IisRest.Contracts.Dtos.Price;

namespace IisRest.Contracts.Dtos.BoughtAsset
{
    [DataContract]
    public class BoughtAssetReadDto
    {
        [DataMember(Order = 0)]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        public DateTime BuyDate { get; set; }

        [DataMember(Order = 2)]
        public double Amount { get; set; }

        [DataMember(Order = 3)]
        public int PriceId { get; set; }

        [DataMember(Order = 4)]
        public int AssetId { get; set; }

        [DataMember(Order = 5)]
        public PriceReadDto Price { get; set; } = default!;

        [DataMember(Order = 6)]
        public AssetReadDto Asset { get; set; } = default!;
    }
}
