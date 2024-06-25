namespace Reactive.Contracts
{
    public class StockMovement
    {
        public string Symbol { get; set; }

        public double PriceChange { get; set; }

        public double StartPrice { get; set; }

        public double EndPrice { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
