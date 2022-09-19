using System.Collections.Generic;

using StockWatch.Assets;

namespace StockWatch.Data
{
    public class RunTimeDataModel
    {
        public List<AssetModel> Assets
        {
            get; set;
        }
        public AssetHistoryModel AssetHistory
        {
            get; set;
        }
    }
}
