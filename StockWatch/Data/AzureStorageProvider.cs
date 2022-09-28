// Code By Wpooley

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Azure;
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

            var query =  client.QueryAsync<AssetModel>($"PartitionKey eq '{asset.PartitionKey}' and RowKey eq '{asset.RowKey}'");
            var enumerator = query.GetAsyncEnumerator();
            bool recordExist = await enumerator.MoveNextAsync(); //We should only have one or zero items
            
            return recordExist ? enumerator.Current : null;
        }

        public async Task SaveHistory(AssetModel asset)
        {
            if (client is null)
            {
                await ConnectToDataStorage();
            }

            await client.UpsertEntityAsync<AssetModel>(asset, TableUpdateMode.Replace);
        }
    }
}
