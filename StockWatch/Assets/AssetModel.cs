using System;
using Azure;
using Azure.Data.Tables;

namespace StockWatch.Assets
{
    public class AssetModel : ITableEntity
    {
        public string Id { get; set; }
        public string Company { get; set; }
        public string Symbol { get; set; }
        public string Url { get; set; }
        public decimal MarketCap { get; set; }
        public decimal PercentChange { get; set; }
        public decimal AvgVolume { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime ReportDate { get; set; }

        /// <summary>
        /// The partition key is a unique identifier for the partition within a given table and forms the first part of an entity's primary key.
        /// </summary>
        /// <value>A string containing the partition key for the entity.</value>
        public string PartitionKey { get; set; }

        /// <summary>
        /// The row key is a unique identifier for an entity within a given partition. Together the <see cref="PartitionKey" /> and RowKey uniquely identify every entity within a table.
        /// </summary>
        /// <value>A string containing the row key for the entity.</value>
        public string RowKey { get; set; }

        /// <summary>
        /// The Timestamp property is a DateTime value that is maintained on the server side to record the time an entity was last modified.
        /// The Table service uses the Timestamp property internally to provide optimistic concurrency. The value of Timestamp is a monotonically increasing value,
        /// meaning that each time the entity is modified, the value of Timestamp increases for that entity.
        /// This property should not be set on insert or update operations (the value will be ignored).
        /// </summary>
        /// <value>A <see cref="DateTimeOffset"/> containing the timestamp of the entity.</value>
        public DateTimeOffset? Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the entity's ETag.
        /// </summary>
        /// <value>A string containing the ETag value for the entity.</value>
        public ETag ETag { get; set; }
    }
    
}
