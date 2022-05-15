namespace IisRest.Contracts.Settings
{
    public class AssetPriceProviderSettings
    {
        public string Url { get; set; } = default!;
        public string Secret { get; set; } = default!;
        public string Host { get; set; } = default!;
    }
}
