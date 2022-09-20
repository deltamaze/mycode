// Code By Wpooley

using Autofac;
using Microsoft.Extensions.Logging;
using StockWatch.Assets;
using StockWatch.Data;
using StockWatch.Notifiers;

namespace StockWatch
{
    public static class ContainerConfig
    {
        public static IContainer Configure(ILogger log)
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance<ILogger>(log);
            builder.RegisterType<RunTimeDataModel>().SingleInstance();
            builder.RegisterType<AzureStorageProvider>().As<IDataStorageProvider>().SingleInstance();
            // builder.RegisterType<TwitterSecretLoader>().As<ISecretLoader>().SingleInstance();
            // builder.RegisterType<YahooStocks>().As<IAssetsProvider>().SingleInstance();
            builder.RegisterType<StubAssetsProvider>().As<IAssetsProvider>().SingleInstance();
            builder.RegisterType<AssetProcessor>().As<IAssetProcessor>().SingleInstance();
            builder.RegisterType<StubNotifierProvider>().As<INotifierProvider>().SingleInstance();
            // builder.RegisterType<TwitterNotifierProvider>().As<INotifierProvider>().SingleInstance();
            builder.RegisterType<NotifierProcessor>().As<INotifierProcessor>().SingleInstance();
            builder.RegisterType<Application>().As<IApplication>();
            return builder.Build();
        }
    }
}
