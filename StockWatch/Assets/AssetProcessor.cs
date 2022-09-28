using Microsoft.Extensions.Logging;
using StockWatch.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockWatch.Assets
{

    public class AssetProcessor : IAssetProcessor
    {
        private readonly IAssetsProvider[] assetsProviders;
        private readonly IDataStorageProvider dbProvider;
        private readonly ILogger log;
        public AssetProcessor(IAssetsProvider[] assetProviders, IDataStorageProvider dbProvider, ILogger log)
        {
            this.assetsProviders = assetProviders;
            this.dbProvider = dbProvider;
            this.log = log;
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
        private bool CheckPercentChange(AssetModel asset)
        {
            if (asset.PercentChange is > 20 or < (-20))
            {
                return true;
            }

            this.log.LogInformation($"Asset {asset.Symbol} Percent Change does not qualify. Value => {asset.PercentChange}");
            return false;
        }

        private bool CheckMarketCap(AssetModel asset)
        {
            if (asset.MarketCap > 5000000000)
            {
                return true;
            }

            this.log.LogInformation($"Asset {asset.Symbol} Market Cap does not qualify. Value => {asset.MarketCap}");
            return false;
        }

        private bool CheckAvgVol(AssetModel asset)
        {
            if (asset.AvgVolume > 100000)
            {
                return true;
            }

            this.log.LogInformation($"Asset {asset.Symbol} Avg Vol does not qualify. Value => {asset.AvgVolume}");
            return false;
        }

        private async Task<bool> CheckHistory(AssetModel asset)
        {
            AssetModel prevRecord = await dbProvider.PullExistingRecord(asset);

            if (prevRecord == null)
            {
                return true;
            }

            if ( DateTimeOffset.Compare((DateTimeOffset) prevRecord.Timestamp, DateTime.UtcNow.AddDays(-3)) < 0)
            {
                // last entry is older 3 days ago, and should trigger notification
                return true;
            }

            this.log.LogInformation($"Asset {asset.Symbol} History Check does not qualify.");
            return false;
        }
    }
}
