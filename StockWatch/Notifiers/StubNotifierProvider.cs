using System.Collections.Generic;
using System.Text;
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
            bool skipInitialLinebreak = true;
            StringBuilder composedMessage = new();
            foreach (AssetModel asset in assets)
            {
                if (skipInitialLinebreak)
                {
                    skipInitialLinebreak = false;
                }
                else
                {
                    composedMessage.AppendLine();
                }

                composedMessage.AppendLine($"Alert! {asset.Symbol} - {asset.Company}");
                composedMessage.AppendLine($"Change Percent: {asset.PercentChange} ");
                composedMessage.AppendLine($"Market Cap: {asset.MarketCap} ");
                composedMessage.AppendLine($"Unit Value: {asset.UnitPrice}");
                composedMessage.AppendLine($"More Info: {asset.Url}");
            }

            log.LogInformation(composedMessage.ToString());
        }
    }
    
}
