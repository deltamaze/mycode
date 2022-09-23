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
        }

        public async Task<AssetModel> PullExistingRecord(AssetModel asset)
        {
            if (client is null)
            {
                await ConnectToDataStorage();
            }
            var prevAssetModel = await client.GetEntityAsync<AssetModel>(asset.PartitionKey, asset.RowKey);
            return prevAssetModel;
        }

        public async Task SaveHistory(AssetModel asset)
        {
            if (client is null)
            {
                await ConnectToDataStorage();
            }
            try
            {
                await client.UpsertEntityAsync<AssetModel>(asset,TableUpdateMode.Replace);
            }
            catch(Exception e)
            {
                return;
            }
        }
    }
}
