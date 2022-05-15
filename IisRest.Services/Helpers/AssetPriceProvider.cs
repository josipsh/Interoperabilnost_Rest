using System.Globalization;
using System.Net;
using CsvHelper;
using IisRest.Contracts.Dtos.Asset;
using IisRest.Contracts.Dtos.Currency;
using IisRest.Contracts.Dtos.Price;
using IisRest.Contracts.Helpers;
using IisRest.Contracts.Repositories;
using IisRest.Contracts.Settings;
using IisRest.Services.ReportService;
using Microsoft.Extensions.Options;

namespace IisRest.Services.Helpers
{
    internal class AssetPriceProvider : IAssetPriceProvider
    {
        private readonly AssetPriceProviderSettings _settings;
        private readonly HttpClient _httpClient;
        private readonly IUnitOfWork _uow;

        public AssetPriceProvider(IOptions<AssetPriceProviderSettings> settings, IUnitOfWork uow)
        {
            _settings = settings.Value;
            _httpClient = new HttpClient();
            _uow = uow;
        }

        public PriceReadDto GetLatestPrice(AssetReadDto asset)
        {
            HttpRequestMessage request = PrepareRequest(asset.Symbol);

            using (HttpResponseMessage response = _httpClient.Send(request))
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception("Unable to fect latest price for asset");
                }

                string body = response.Content.ReadAsStringAsync().Result;

                return ParseLatestPrice(body);
            }
        }

        private HttpRequestMessage PrepareRequest(string symbol)
        {
            return new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_settings.Url}/query?market=CNY&symbol=BTC&function=DIGITAL_CURRENCY_DAILY&outputsize=full&datatype=csv"),
                Headers =
                {
                    { "X-RapidAPI-Host", $"{_settings.Host}" },
                    { "X-RapidAPI-Key", $"{_settings.Secret}" },
                },
            };
        }

        private PriceReadDto ParseLatestPrice(string body)
        {
            using (var reader = new StringReader(body))
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csvReader.Read();
                csvReader.ReadHeader();
                csvReader.Read();

                PriceCsvRow firstRow = csvReader.GetRecord<PriceCsvRow>();
                CurrencyReadDto currency = _uow.CurrencyRepository.GetCurrencyBySymbol("USD")?.ToReadDto()
                        ?? new CurrencyReadDto { Name = "American dollar", Symbol = "USD" };

                return new PriceReadDto
                {
                    PriceDate = DateTime.ParseExact(firstRow.Timestamp, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    PriceRate = double.Parse(firstRow.CloseUSD),
                    Currency = currency,
                };
            }
        }
    }
}
