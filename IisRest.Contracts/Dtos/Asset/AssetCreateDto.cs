using System.Runtime.Serialization;
using IisRest.Contracts.Entities;

namespace IisRest.Contracts.Dtos.Asset
{
    [DataContract]
    public class AssetCreateDto
    {
        [DataMember(Order = 0)]
        public string Name { get; set; } = default!;

        [DataMember(Order = 1)]
        public string Symbol { get; set; } = default!;

        [DataMember(Order = 2)]
        public AssetType AssetType { get; set; } = default!;

        public Entities.Asset ToModel()
        {
            return new Entities.Asset()
            {
                Name = Name,
                Symbol = Symbol,
                AssetType = AssetType,
            };
        }
    }
}
