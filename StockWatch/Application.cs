using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockWatch.Assets;
using StockWatch.Configuration;
using StockWatch.Data;
using StockWatch.Notifiers;

namespace StockWatch
{

    class Application : IApplication
    {
        private IAssetProcessor assetProcessors;
        private RunTimeDataModel runData;
        private IDatabaseProvider dbProvider;
        private INotifierProcessor notifierProcessor;
        private ISecretProcessor secretProcessor;
        private ILogger log;
        public Application(
            IAssetProcessor assetProcessors,
            RunTimeDataModel runData,
            IDatabaseProvider dbProvider,
            INotifierProcessor notifierProcessor,
            ISecretProcessor secretProcessor,
            ILogger log
        )
        {
            this.assetProcessors = assetProcessors;
            this.runData = runData;
            this.dbProvider = dbProvider;
            this.notifierProcessor = notifierProcessor;
            this.secretProcessor = secretProcessor;
            this.log = log;
        }


        public async Task Run()
        {
            log.LogInformation("Starting Run");
            log.LogInformation("Load Secrets from json");
            secretProcessor.LoadSecrets();

            log.LogInformation("Connect to Database");
            await dbProvider.ConnectToDatabase();

            //log.LogInformation("Get Recent Assets Activity From Web Endpoints");
            //runData.Assets = assetProcessors.GetAssets();
            //if (runData.Assets.Count == 0)
            //{
            //    log.LogInformation("No Assets pulled, ending run");
            //}
            //log.LogInformation($"Assets pulled: {runData.Assets.Count}");


            //log.LogInformation("Clear Assets that don't meet requirements");
            //int removeCount = assetProcessors.RemoveAssetsBelowTreshold(runData.Assets);
            //log.LogInformation($"Assets Removed:{removeCount} Assets Remaining:{runData.Assets.Count}");

            //if (runData.Assets.Count == 0)
            //{
            //    log.LogInformation("No Assets left, ending run");
            //}

            ////TEST
            //notifierProcessor.Notify(runData.Assets);

            //log.LogInformation("Pull History For these Assets from our Database");
            //runData.AssetHistory = await dbProvider.GetHistory(runData.Assets);
            //log.LogInformation($"Historical Records pulled:{runData.AssetHistory.Count}");

            //log.LogInformation("Remove Assets that have been recently reported on");
            //removeCount = assetProcessors.RemoveFromRecentReporting(
            //    runData.Assets,
            //    runData.AssetHistory);
            //log.LogInformation($"Assets Removed:{removeCount} Assets Remaining:{runData.Assets.Count}");

            //if (runData.Assets.Count == 0)
            //{
            //    log.LogInformation("No Assets left, ending run");
            //}

            //log.LogInformation("Save the remaining assets into the DB");
            //await dbProvider.SaveHistory(runData.Assets);

            //log.LogInformation("Broadcast Alerts to Web Endpoints");
            //notifierProcessor.Notify(runData.Assets);
            //log.LogInformation("Ending Run");

        }
    }
}
