using System.Runtime.Serialization;
using IisRest.Contracts.Entities;

namespace IisRest.Contracts.Dtos.Asset
{
    [DataContract]
    public class AssetReadDto
    {
        [DataMember(Order = 0)]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        public string Name { get; set; } = default!;

        [DataMember(Order = 2)]
        public string Symbol { get; set; } = default!;

        [DataMember(Order = 3)]
        public AssetType AssetType { get; set; } = default!;
    }
}
