using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace StockWatch
{

    class Application : IApplication
    {
        //private IAssetProcessor assetProcessors;
        //private RunTimeDataModel runData;
        //private IDatabaseProvider dbProvider;
        //private INotifierProcessor notifierProcessor;
        //private ISecretProcessor secretProcessor;
        //public Application(
        //    IAssetProcessor assetProcessors,
        //    RunTimeDataModel runData,
        //    IDatabaseProvider dbProvider,
        //    INotifierProcessor notifierProcessor,
        //    ISecretProcessor secretProcessor
        //)
        //{
        //    this.assetProcessors = assetProcessors;
        //    this.runData = runData;
        //    this.dbProvider = dbProvider;
        //    this.notifierProcessor = notifierProcessor;
        //    this.secretProcessor = secretProcessor;
        //}


        public async Task Run(ILogger log)
        {


            //log.Info("Starting Run");
            //log.Info("Load Secrets from json");
            //secretProcessor.LoadSecrets();

            //log.Info("Connect to Database");
            //await dbProvider.ConnectToDatabase();

            //log.Info("Get Recent Assets Activity From Web Endpoints");
            //runData.Assets = assetProcessors.GetAssets();
            //if (runData.Assets.Count == 0)
            //{
            //    log.Info("No Assets pulled, ending run");
            //}
            //log.Info($"Assets pulled: {runData.Assets.Count}");


            //log.Info("Clear Assets that don't meet requirements");
            //int removeCount = assetProcessors.RemoveAssetsBelowTreshold(runData.Assets);
            //log.Info($"Assets Removed:{removeCount} Assets Remaining:{runData.Assets.Count}");

            //if (runData.Assets.Count == 0)
            //{
            //    log.Info("No Assets left, ending run");
            //}

            ////TEST
            //notifierProcessor.Notify(runData.Assets);

            //log.Info("Pull History For these Assets from our Database");
            //runData.AssetHistory = await dbProvider.GetHistory(runData.Assets);
            //log.Info($"Historical Records pulled:{runData.AssetHistory.Count}");

            //log.Info("Remove Assets that have been recently reported on");
            //removeCount = assetProcessors.RemoveFromRecentReporting(
            //    runData.Assets,
            //    runData.AssetHistory);
            //log.Info($"Assets Removed:{removeCount} Assets Remaining:{runData.Assets.Count}");

            //if (runData.Assets.Count == 0)
            //{
            //    log.Info("No Assets left, ending run");
            //}

            //log.Info("Save the remaining assets into the DB");
            //await dbProvider.SaveHistory(runData.Assets);

            //log.Info("Broadcast Alerts to Web Endpoints");
            //notifierProcessor.Notify(runData.Assets);
            //log.Info("Ending Run");

        }
    }
}
