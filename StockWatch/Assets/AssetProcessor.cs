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
            List<AssetModel> assets = new List<AssetModel>();
            foreach (IAssetsProvider provider in assetsProviders)
            {
                assets.AddRange(provider.GetAssets());
            }

            return assets;
        }
        public async Task SaveHistory(List<AssetModel> assets)
        {
            foreach (AssetModel asset in assets)
            {
                dbProvider.SaveHistory(asset);
            }
        }
        public async Task<int> RemoveNonQualifyingAssets(List<AssetModel> assets)
        {
            int assetsLen = assets.Count();
            int removeCount = 0;
            for (int x = assetsLen - 1; x >= 0; x -= 1)
            {
                bool keepAsset = CheckPercentChange(assets[x]) ||
                    CheckMarketCap(assets[x]) ||
                    CheckAvgVol(assets[x]);
                if (!keepAsset)
                {
                    removeCount += 1;
                    assets.RemoveAt(x);
                }
            }

            return removeCount;
        }
        private bool CheckPercentChange(AssetModel asset)
        {
            if (asset.PercentChange > 20 || asset.PercentChange < -20)
            {
                return true;
            }

            return false;
        }

        private bool CheckMarketCap(AssetModel asset)
        {
            if (asset.MarketCap > 5000000000)
            {
                return true;
            }

            return false;
        }

        private bool CheckAvgVol(AssetModel asset)
        {
            if (asset.AvgVolume > 100000)
            {
                return true;
            }

            return false;
        }

        private bool CheckHistory(AssetHistoryModel assetsHistory)
        {
            if (DateTime.Compare(assetsHistory.LastEntry,
                System.DateTime.Now.AddDays(-3)) < 0)
            {
                // last entry is earlier than 3 days ago, so good to re-report
                return true;
            }

            return false;
        }
    }
}
