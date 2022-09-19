using System.Collections.Generic;
using System.Threading.Tasks;
using StockWatch.Assets;

namespace StockWatch.Data
{
    public interface IDataStorageProvider
    {
        Task ConnectToDataStorage();
        Task<AssetModel> PullExistingRecord(AssetModel asset);
        Task SaveHistory(AssetModel asset);
    
    }
}
