using StockWatch.Assets;
using System.Collections.Generic;

namespace StockWatch.Notifiers
{
    public class TwitterNotifierProvider : INotifierProvider
    {
        public TwitterNotifierProvider()
        {
            // Pull Cred from Env Variables
        }
        public void Notify(List<AssetModel> assets)
        {

        }
    }
}
