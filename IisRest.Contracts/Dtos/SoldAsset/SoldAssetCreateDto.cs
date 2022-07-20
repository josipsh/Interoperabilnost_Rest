using System.Runtime.Serialization;

namespace IisRest.Contracts.Dtos.SoldAsset
{
    [DataContract]
    public class SoldAssetCreateDto
    {
        [DataMember(Order = 0)]
        public DateTime SellDate { get; set; }

        [DataMember(Order = 1)]
        public double Amount { get; set; }

        [DataMember(Order = 2)]
        public int AssetId { get; set; } = default!;

        [DataMember(Order = 3)]
        public int CurrencyId { get; set; }

        [DataMember(Order = 4)]
        public double PriceRate { get; set; }

        [DataMember(Order = 5)]
        public DateTime PriceDate { get; set; }

        public Entities.SoldAsset ToModel()
        {
            return new Entities.SoldAsset()
            {
                Amount = Amount,
                SellDate = SellDate,
                AssetId = AssetId,
            };
        }
    }
}
