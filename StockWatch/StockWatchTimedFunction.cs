using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Autofac;
using static System.Net.Mime.MediaTypeNames;


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
            try
            {
                IContainer container = ContainerConfig.Configure(log);

                using (ILifetimeScope scope = container.BeginLifetimeScope())
                {
                    IApplication app = scope.Resolve<IApplication>();
                    app.Run().Wait();
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Unhandled Exception");
            }
        }
    }
}
