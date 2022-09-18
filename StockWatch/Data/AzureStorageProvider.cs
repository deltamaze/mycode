// Code By Wpooley

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Data.Tables;
using StockWatch.Assets;


namespace StockWatch.Data
{
    public class AzureStorageProvider : IDataStorageProvider
    {
        string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTIONSTRING");

        public async Task ConnectToDataStorage()
        {
            #if DEBUG
                connectionString = "UseDevelopmentStorage=true";
            #endif
            var client = new TableClient(connectionString,"StockWatch");
            await client.CreateIfNotExistsAsync();
            // client.GetEntity<string>()
            client.AddEntity<AssetModel>(new AssetModel() {
                Symbol = "TEST",
                PartitionKey = "TEST",
                Timestamp = DateTime.UtcNow,
                ReportDate = DateTime.UtcNow,
                RowKey = "TESTROW"
            });
            return;
        }

        public async Task<Dictionary<string, AssetHistoryModel>> GetHistory(List<AssetModel> assets)
        {
            return new Dictionary<string, AssetHistoryModel>();
        }

        public Task SaveHistory(List<AssetModel> asset)
        {
            return Task.CompletedTask;
        }
    }
}
