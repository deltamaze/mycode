using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace StockWatch
{
    public class StockWatchTimedFunction
    {
        [FunctionName("StockWatchTimedFunction")]
        public void Run([TimerTrigger("1 * * * *",
            #if DEBUG
                RunOnStartup = true
            #else
                RunOnStartup = false
            #endif
            )]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
