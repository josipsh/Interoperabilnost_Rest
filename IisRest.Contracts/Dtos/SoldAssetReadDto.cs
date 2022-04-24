namespace IisRest.Contracts.Dtos
{
    public class SoldAssetReadDto
    {
        public int Id { get; set; }
        public DateTime SellDate { get; set; }
        public double Amount { get; set; }
        public PriceReadDto Price { get; set; } = default!;
        public AssetReadDto Asset { get; set; } = default!;
    }
}
