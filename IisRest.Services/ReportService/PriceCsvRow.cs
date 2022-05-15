using CsvHelper.Configuration.Attributes;

namespace IisRest.Services.ReportService
{
    internal class PriceCsvRow
    {
        [Name("timestamp")]
        public string Timestamp { get; set; } = default!;

        [Name("open (USD)")]
        public string OpenUSD { get; set; } = default!;

        [Name("high (USD)")]
        public string HighUSD { get; set; } = default!;

        [Name("low (USD)")]
        public string LowUSD { get; set; } = default!;

        [Name("close (USD)")]
        public string CloseUSD { get; set; } = default!;
    }
}
