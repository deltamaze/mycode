using Microsoft.Extensions.Logging;
using StockWatch.Assets;
using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi;

namespace StockWatch.Notifiers
{
    public class TwitterNotifierProvider : INotifierProvider
    {
        private readonly string accessSecret;
        private readonly string accessToken;
        private readonly string apiKey;
        private readonly string apiSecret;
        private readonly ILogger log;
        public TwitterNotifierProvider(ILogger log)
        {
            accessSecret = Environment.GetEnvironmentVariable("StockWatchTwitterAccessSecret");
            accessToken = Environment.GetEnvironmentVariable("StockWatchTwitterAccessToken");
            apiKey = Environment.GetEnvironmentVariable("StockWatchTwitterApiKey");
            apiSecret = Environment.GetEnvironmentVariable("StockWatchTwitterApiSecret");
            this.log = log;

        }
        public async void Notify(List<AssetModel> assets)
        {
            log.LogInformation("Starting Tweet Process");
            if (string.IsNullOrWhiteSpace(accessSecret) ||
                string.IsNullOrWhiteSpace(accessToken) ||
                string.IsNullOrWhiteSpace(apiKey) ||
                string.IsNullOrWhiteSpace(apiSecret)
                )
            {
                log.LogInformation("Twitter Keys not found, skipping Tweet Notifications");
                return;
            }

            try
            {
                // Twitter has character limit, so lets send one tweet per asset and keep message brief.
                foreach (var asset in assets)
                {
                    string tweetMessage = FormatTweetMessage(asset);
                    TwitterClient client = new(apiKey, apiSecret, accessToken, accessSecret);
                    await client.Tweets.PublishTweetAsync(tweetMessage);
                    log.LogInformation($"Tweet Posted for {asset.Symbol}");
                    // wait a bit to not slam twitter api
                    System.Threading.Thread.Sleep(5000);
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex, $"Exception During Twitter Notification Attempt ex =>{ex.Message} innerex=> {(ex.InnerException != null ? ex.InnerException.Message : "null")}");
            }
        }

        private static string FormatTweetMessage(AssetModel asset)
        {

            StringBuilder composedMessage = new();

            composedMessage.AppendLine($"{asset.Symbol} - {asset.Company}");
            composedMessage.AppendLine($"Change Percent: {asset.PercentChange} ");
            composedMessage.AppendLine($"More Info: {asset.Url}");

            return composedMessage.ToString();
        }
    }
}
