using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace StockWatch
{
    interface IApplication
    {
        Task Run(ILogger log);
    }
}
