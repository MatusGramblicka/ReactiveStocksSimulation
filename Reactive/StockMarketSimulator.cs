using Reactive.Contracts;
using System.Reactive.Linq;

namespace Reactive
{
    public static class StockMarketSimulator
    {
        private static readonly Random rand = new();
        private static readonly string[] symbols =
        [
            "AAPL",
            "MSFT",
            "GOOGL",
            "AMZN",
            "FB"
        ];

        public static IObservable<StockTick> GetStockStream()
        {
            return Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(_ => new StockTick
                {
                    Symbol = symbols[rand.Next(symbols.Length)],
                    Price = Math.Round(100 + (rand.NextDouble() * 1000), 2),
                    Timestamp = DateTime.Now
                });
        }
    }
}
