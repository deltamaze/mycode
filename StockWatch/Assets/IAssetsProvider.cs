using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockWatch.Assets
{
    public interface IAssetsProvider
    {
        Task<IEnumerable<AssetModel>> GetAssets();
    }
}
