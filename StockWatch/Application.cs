using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockWatch.Assets;
using StockWatch.Data;
using StockWatch.Notifiers;

namespace StockWatch
{

    public class Application : IApplication
    {
        private readonly IAssetProcessor assetProcessors;
        private readonly RunTimeDataModel runData;
        private readonly INotifierProcessor notifierProcessor;
        private readonly ILogger log;
        public Application(
            IAssetProcessor assetProcessors,
            RunTimeDataModel runData,
            INotifierProcessor notifierProcessor,
            ILogger log
        )
        {
            this.assetProcessors = assetProcessors;
            this.runData = runData;
            this.notifierProcessor = notifierProcessor;
            this.log = log;
        }

        public async Task Run()
        {
            log.LogInformation("Starting Run");

            log.LogInformation("Get Recent Assets Activity From Web Endpoints");
            runData.Assets = await assetProcessors.GetAssets();

            log.LogInformation($"Assets pulled: {runData.Assets.Count}");
            if (this.EndRunIfNoAssets())
            {
                return;
            }

            log.LogInformation("Clear Assets that don't meet requirements");
            int removeCount = await assetProcessors.RemoveNonQualifyingAssets(runData.Assets);
            log.LogInformation($"Assets Removed:{removeCount} Assets Remaining:{runData.Assets.Count}");

            if (this.EndRunIfNoAssets())
            {
                return;
            }

            log.LogInformation("Save the remaining assets into the DB");
            await assetProcessors.SaveHistory(runData.Assets);

            log.LogInformation("Broadcast Alerts to Web Endpoints");
            notifierProcessor.Notify(runData.Assets);

            log.LogInformation("Ending Run");

        }

        private bool EndRunIfNoAssets()
        {
            if (runData.Assets.Count == 0)
            {
                log.LogInformation("No Assets left, ending run");
                return true;
            }

            return false;
        }
    }
}
