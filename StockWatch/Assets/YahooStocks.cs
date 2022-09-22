using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace StockWatch.Assets
{
    public class YahooStocks : IAssetsProvider
    {
        private const string GainingStocksUrl = "https://query1.finance.yahoo.com/v1/finance/screener/predefined/saved?formatted=true&lang=en-US&region=US&scrIds=day_gainers&start=0&count=10";
        private const string LosingStocksUrl = "https://query2.finance.yahoo.com/v1/finance/screener/predefined/saved?formatted=true&lang=en-US&region=US&scrIds=day_losers&start=0&count=10";

        public async Task<IEnumerable<AssetModel>> GetAssets()
        {
            List<AssetModel> returnAssets = new();
            returnAssets.AddRange(await GainingAssets());
            returnAssets.AddRange(await LosingAssets());
            return returnAssets;
        }
        private async Task<IEnumerable<AssetModel>> GainingAssets()
        {
            YahooStockModel assets = await GetYahooStocks(GainingStocksUrl);
            return ParseYahooStocks(assets);
        }
        private async Task<IEnumerable<AssetModel>> LosingAssets()
        {
            YahooStockModel assets = await GetYahooStocks(LosingStocksUrl);
            return ParseYahooStocks(assets);
        }
        private static async Task<YahooStockModel> GetYahooStocks(string url)
        {
            HttpClient client = new();
            string reply = await client.GetStringAsync(url);
            return JsonSerializer.Deserialize<YahooStockModel>(reply);
        }
        private static List<AssetModel> ParseYahooStocks(YahooStockModel yahooStocks)
        {
            List<AssetModel> returnList = new();
            // null checks
            if (
                yahooStocks == null ||
                yahooStocks.finance == null ||
                yahooStocks.finance.result == null ||
                yahooStocks.finance.result.Count < 1 ||
                yahooStocks.finance.result[0].quotes == null)
            {
                return returnList;
            }

            foreach (var quote in yahooStocks.finance.result[0].quotes)
            {
                AssetModel stock = new()
                {
                    PartitionKey = "Stock",
                    RowKey = quote.symbol,
                    Timestamp = DateTime.UtcNow,
                    Company = quote.longName,
                    Symbol = quote.symbol
                };
                stock.Url = @"https://finance.yahoo.com/quote/" + stock.Symbol + @"/";
                stock.MarketCap = decimal.Parse(quote.marketCap.longFmt.Replace(",", ""));
                stock.PercentChange = ((decimal) quote.regularMarketChangePercent.raw);
                stock.AvgVolume = ((decimal) quote.averageDailyVolume3Month.raw);
                stock.UnitPrice = ((decimal) quote.regularMarketPrice.raw);
                returnList.Add(stock);
            }

            return returnList;

        }
    }
}
