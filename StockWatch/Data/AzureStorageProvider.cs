// Code By Wpooley

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using StockWatch.Assets;


namespace StockWatch.Data
{
    public class AzureStorageProvider : IDataStorageProvider
    {
        var host = Environment.GetEnvironmentVariable("AZURE_STORAGE_HOST");
        var account = Environment.GetEnvironmentVariable("AZURE_STORAGE_ACCOUNT");
        var container = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONTAINER");
        var emulator = account == "devstoreaccount1";
        var uri = $"https://{(emulator ? $"{host}/{account}" : $"{account}.{host}")}/{container}";

        public Task ConnectToDataStorage()
        {
            var client = new BlobContainerClient(new Uri(""), new DefaultAzureCredential());
            return Task.CompletedTask;
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
