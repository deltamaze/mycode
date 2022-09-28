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
            apiSecret = Environment.GetEnvironmentVariable("StockWatchTwitterApiKey");
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

            string tweetMessage = FormatTweetMessage(assets);
            TwitterClient client = new(apiKey, apiSecret, accessToken, accessSecret);
            await client.Tweets.PublishTweetAsync(tweetMessage);
            log.LogInformation("Tweets Posted");
        }

        private static string FormatTweetMessage(List<AssetModel> assets)
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

            return composedMessage.ToString();
        }
    }
}
