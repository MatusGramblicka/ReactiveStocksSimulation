namespace Reactive.Contracts
{
    public class StockTick
    {
        public string Symbol { get; set; }

        public double Price { get; set; }

        public DateTime Timestamp { get; set; }
    }

}
