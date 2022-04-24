namespace IisRest.Contracts.Dtos
{
    public class SoldAssetCreateDto
    {
        public DateTime SellDate { get; set; }
        public double Amount { get; set; }
        public PriceCreateDto Price { get; set; } = default!;
        public AssetCreateDto Asset { get; set; } = default!;
    }
}
