using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockWatch.Assets
{
    public class StubAssetsProvider : IAssetsProvider
    {
        public Task<IEnumerable<AssetModel>> GetAssets()
        {
            List<AssetModel> returnAssets = new List<AssetModel>() ;
            returnAssets.Add(new AssetModel("Stocks", "TST1")
            {
                Company = "Test1",
                Symbol = "TST1",
                Url = "test1.com",
                MarketCap = 6000000000.2M,
                PercentChange = 31M,
                AvgVolume = 31000000M,
                UnitPrice = 25.3M,

            });
            returnAssets.Add(new AssetModel("Stocks", "TST2")
            {
                Company = "Test2",
                Symbol = "TST2",
                Url = "test2.com",
                MarketCap = 9000002.1M,
                PercentChange = 24M,
                AvgVolume = 3200000M,
                UnitPrice = 24M,
            });
            returnAssets.Add(new AssetModel("Stocks", "TST3")
            {
                Company = "Test3",
                Symbol = "TST3",
                Url = "test3.com",
                MarketCap = 999999999M,
                PercentChange = -30M,
                AvgVolume = 3304235M,
                UnitPrice = 23M,
            });
            returnAssets.Add(new AssetModel("Stocks", "TST4")
            {
                Company = "Test4",
                Symbol = "TST4",
                Url = "test4.com",
                MarketCap = 9995345999M,
                PercentChange = -29M,
                AvgVolume = 342000M,
                UnitPrice = 22M,
            });

            return Task.FromResult((IEnumerable<AssetModel>)returnAssets);
        }
    }
}
