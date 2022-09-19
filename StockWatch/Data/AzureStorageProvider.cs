// Code By Wpooley

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Azure.Data.Tables;
using StockWatch.Assets;

namespace StockWatch.Data
{
    public class AzureStorageProvider : IDataStorageProvider
    {
        private string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTIONSTRING");

        private TableClient client;

        public async Task ConnectToDataStorage()
        {
            #if DEBUG
                connectionString = "UseDevelopmentStorage=true";
            #endif
            client = new TableClient(connectionString, "StockWatch");
            await client.CreateIfNotExistsAsync();
            return;
        }

        public async Task<AssetModel> PullExistingRecord(AssetModel asset)
        {
            var prevAssetModel = await client.GetEntityAsync<AssetModel>(asset.PartitionKey, asset.RowKey);
            return prevAssetModel;
        }

        public async Task SaveHistory(AssetModel asset)
        {
            await client.UpsertEntityAsync<AssetModel>(asset);
            return;
        }
    }
}
