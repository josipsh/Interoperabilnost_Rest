using IisRest.Contracts.Helpers;
using IisRest.Contracts.Repositories;
using IisRest.Contracts.Settings;
using Microsoft.Extensions.Options;

namespace IisRest.Services.Helpers
{
    public class HelpersWraper : IHelpersWraper
    {
        private IAssetPriceProvider _assetPriceProvider;

        public IAssetPriceProvider AssetPriceProvider => _assetPriceProvider;

        public HelpersWraper(IOptions<AssetPriceProviderSettings> assetProiceProviderSettings, IUnitOfWork uow)
        {
            _assetPriceProvider = new AssetPriceProvider(assetProiceProviderSettings, uow);
        }
    }
}
