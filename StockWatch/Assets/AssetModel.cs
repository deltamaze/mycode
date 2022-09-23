using System;
using System.Collections.Concurrent;
using Azure;
using Azure.Data.Tables;

namespace StockWatch.Assets
{
    public class AssetModel : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string Company { get; set; }
        public string Symbol { get; set; }
        public string Url { get; set; }
        public decimal MarketCap { get; set; }
        public decimal PercentChange { get; set; }
        public decimal AvgVolume { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
        public bool PreviousReport { get; set; }

        public AssetModel(string partitionKey, string rowKey)
        {
            this.PartitionKey = partitionKey;
            this.RowKey = rowKey;
            this.Timestamp = DateTimeOffset.Now;
        }

        public AssetModel()
        {

        }
    }
}
