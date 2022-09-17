using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using StockWatch.Assets;

namespace StockWatch.Notifiers
{
    public class StubNotifierProvider : INotifierProvider
    {
        private ILogger log;
        public StubNotifierProvider(ILogger log)
        {
            this.log = log;
        }
        public void Notify(List<AssetModel> assets)
        {
            foreach(AssetModel asset in assets)
            {
                log.LogInformation
                (
                    $"Notify Stub for Asset {asset.Symbol}\n"+
                    $"Change Percent: {asset.PercentChange} etc.."
                );
            }
        }
    }
    
}
