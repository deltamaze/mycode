using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace StockWatch
{
    public class StockWatchFuncTimedFunction
    {
        [FunctionName("StockWatchTimedFunction")]
        public static void Run([TimerTrigger("1 1 * * *",
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
