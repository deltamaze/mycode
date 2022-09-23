using StockWatch.Data;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;

namespace StockWatch.Assets
{

    public class AssetProcessor : IAssetProcessor
    {
        private readonly IAssetsProvider[] assetsProviders;
        private readonly IDataStorageProvider dbProvider;
        public AssetProcessor(IAssetsProvider[] assetProviders, IDataStorageProvider dbProvider)
        {
            this.assetsProviders = assetProviders;
            this.dbProvider = dbProvider;
        }
        public async Task<List<AssetModel>> GetAssets()
        {
            List<AssetModel> assets = new();
            foreach (IAssetsProvider provider in assetsProviders)
            {
                assets.AddRange(await provider.GetAssets());
            }

            return assets;
        }
        public async Task SaveHistory(List<AssetModel> assets)
        {
            foreach (AssetModel asset in assets)
            {
                await dbProvider.SaveHistory(asset);
            }
        }
        public async Task<int> RemoveNonQualifyingAssets(List<AssetModel> assets)
        {
            int assetsLen = assets.Count;
            int removeCount = 0;
            for (int x = assetsLen - 1; x >= 0; x -= 1)
            {
                bool keepAsset = CheckPercentChange(assets[x]) &&
                    CheckMarketCap(assets[x]) &&
                    CheckAvgVol(assets[x]) &&
                    await CheckHistory(assets[x]);
                if (!keepAsset)
                {
                    removeCount += 1;
                    assets.RemoveAt(x);
                    continue;
                }
            }

            return removeCount;
        }
        private static bool CheckPercentChange(AssetModel asset) => asset.PercentChange is > 20 or < (-20);

        private static bool CheckMarketCap(AssetModel asset) => asset.MarketCap > 5000000000;

        private static bool CheckAvgVol(AssetModel asset) => asset.AvgVolume > 100000;

        private async Task<bool> CheckHistory(AssetModel asset)
        {
            AssetModel prevRecord = await dbProvider.PullExistingRecord(asset);

            if (prevRecord != null && DateTimeOffset.Compare((DateTimeOffset) prevRecord.Timestamp,DateTime.UtcNow.AddDays(-3)) < 0)
            {
                // last entry is earlier than 3 days ago, so good to re-report
                return true;
            }

            return false;
        }
    }
}
