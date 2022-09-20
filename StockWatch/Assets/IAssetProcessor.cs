using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockWatch.Assets
{
    public interface IAssetProcessor
    {
        Task<List<AssetModel>> GetAssets();
        Task<int> RemoveNonQualifyingAssets(List<AssetModel> assets);
        Task SaveHistory(List<AssetModel> assets);
    }
}
