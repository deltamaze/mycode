// Code By Wpooley

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockWatch.Assets;

namespace StockWatch.Data
{
    public class StubDatabaseProvider : IDatabaseProvider
    {
        public Task ConnectToDatabase()
        {
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
