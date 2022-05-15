using IisRest.Contracts.Dtos.BoughtAsset;
using IisRest.Contracts.Dtos.ReportDtos;
using IisRest.Contracts.Dtos.SoldAsset;
using IisRest.Contracts.Entities;
using IisRest.Contracts.Helpers;
using IisRest.Contracts.Repositories;
using IisRest.Contracts.Services;

namespace IisRest.Services.ReportService
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _uow;
        private readonly IHelpersWraper _helpers;

        public ReportService(IUnitOfWork unitOfWork, IHelpersWraper helpers)
        {
            _uow = unitOfWork;
            _helpers = helpers;
        }

        public List<ReportReadDto> GetFullReport(int userId)
        {
            List<SoldAsset> soldAssets = _uow.SoldAssetRepository.GetAll().Where(x => x.ProfileId == userId).ToList();
            List<BoughtAsset> boughtAssets = _uow.BoughtAssetRepository.GetAll().Where(x => x.ProfileId == userId).ToList();

            Dictionary<string, List<SoldAsset>> soldAssetMap = SortSoldAssetData(soldAssets);
            Dictionary<string, List<BoughtAsset>> boughtAssetMap = SortBoughtAssetData(boughtAssets);

            return CreateFullReport(soldAssetMap, boughtAssetMap);
        }

        private List<ReportReadDto> CreateFullReport(
            Dictionary<string, List<SoldAsset>> soldAssetMap,
            Dictionary<string, List<BoughtAsset>> boughtAssetMap)
        {
            List<ReportReadDto> report = new List<ReportReadDto>();

            foreach (KeyValuePair<string, List<SoldAsset>> item in soldAssetMap)
            {
                if (boughtAssetMap.ContainsKey(item.Key))
                {
                    report.Add(new ReportReadDto()
                    {
                        Asset = item.Value[0].AssetPrice.Asset.ToReadDto(),
                        SoldAsstes = item.Value.Select(x => x.ToReadDto()).ToList(),
                        BoughtAssets = boughtAssetMap[item.Key].Select(x => x.ToReadDto()).ToList(),
                    });
                    boughtAssetMap.Remove(item.Key);
                }
                else
                {
                    report.Add(new ReportReadDto()
                    {
                        Asset = item.Value[0].AssetPrice.Asset.ToReadDto(),
                        SoldAsstes = item.Value.Select(x => x.ToReadDto()).ToList(),
                        BoughtAssets = new List<BoughtAssetReadDto>(),
                    });
                }
            }

            if (boughtAssetMap.Count > 0)
            {
                AppendLeftBoughtAssets(report, boughtAssetMap);
            }

            FillWithCurrentPriceForEachAsset(report);

            return report;
        }

        private Dictionary<string, List<SoldAsset>> SortSoldAssetData(List<SoldAsset> soldAssets)
        {
            Dictionary<string, List<SoldAsset>> map = new Dictionary<string, List<SoldAsset>>();

            foreach (SoldAsset item in soldAssets)
            {
                if (map.ContainsKey(item.AssetPrice.Asset.Name))
                {
                    map[item.AssetPrice.Asset.Name].Add(item);
                }
                else
                {
                    map[item.AssetPrice.Asset.Name] = new List<SoldAsset>() { item };
                }
            }

            return map;
        }

        private Dictionary<string, List<BoughtAsset>> SortBoughtAssetData(List<BoughtAsset> boughtAssets)
        {
            Dictionary<string, List<BoughtAsset>> map = new Dictionary<string, List<BoughtAsset>>();

            foreach (BoughtAsset item in boughtAssets)
            {
                if (map.ContainsKey(item.AssetPrice.Asset.Name))
                {
                    map[item.AssetPrice.Asset.Name].Add(item);
                }
                else
                {
                    map[item.AssetPrice.Asset.Name] = new List<BoughtAsset>() { item };
                }
            }

            return map;
        }

        private void AppendLeftBoughtAssets(List<ReportReadDto> report, Dictionary<string, List<BoughtAsset>> boughtAssetMap)
        {
            foreach (KeyValuePair<string, List<BoughtAsset>> item in boughtAssetMap)
            {
                if (boughtAssetMap.ContainsKey(item.Key))
                {
                    report.Add(new ReportReadDto()
                    {
                        Asset = item.Value[0].AssetPrice.Asset.ToReadDto(),
                        SoldAsstes = new List<SoldAssetReadDto>(),
                        BoughtAssets = boughtAssetMap[item.Key].Select(x => x.ToReadDto()).ToList(),
                    });
                }
            }
        }

        private void FillWithCurrentPriceForEachAsset(List<ReportReadDto> report)
        {
            foreach (ReportReadDto item in report)
            {
                item.CurrentPrice = _helpers.AssetPriceProvider.GetLatestPrice(item.Asset);
            }
        }
    }
}
