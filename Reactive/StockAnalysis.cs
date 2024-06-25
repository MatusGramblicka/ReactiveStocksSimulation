using Reactive.Contracts;
using System.Reactive.Linq;

namespace Reactive
{
    public class StockAnalysis
    {
        public static IObservable<StockMovement?> AnalyzeStockTicks()
        {
            IObservable<StockTick> stockStream = StockMarketSimulator.GetStockStream();

            return stockStream
                .GroupBy(tick => tick.Symbol)
                .SelectMany(group => group.Buffer(TimeSpan.FromSeconds(30)))
                .Select(buffer =>
                {
                    var firstTick = buffer.First();
                    var lastTick = buffer.Last();

                    // Avoid potential issues if the buffer is empty
                    if (firstTick == null || lastTick == null) 
                        return null;

                    var priceChange = Math.Abs((lastTick.Price - firstTick.Price) / firstTick.Price);

                    return new StockMovement
                    {
                        Symbol = firstTick.Symbol,
                        PriceChange = priceChange,
                        StartPrice = firstTick.Price,
                        EndPrice = lastTick.Price,
                        Timestamp = lastTick.Timestamp
                    };
                })
                .Where(x => x != null && x.PriceChange > 0.05); // Filter for more than 5% price change   
        }
    }
}
