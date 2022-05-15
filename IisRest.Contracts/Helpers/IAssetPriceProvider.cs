using IisRest.Contracts.Dtos.Asset;
using IisRest.Contracts.Dtos.Price;

namespace IisRest.Contracts.Helpers
{
    public interface IAssetPriceProvider
    {
        PriceReadDto GetLatestPrice(AssetReadDto asset);
    }
}
