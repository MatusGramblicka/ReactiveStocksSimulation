using Reactive.Contracts;

namespace Reactive
{
    public class SignificantMovementActor
    {

        public SignificantMovementActor(IObservable<StockMovement?> significantMovements)
        {
            significantMovements.Subscribe(movement =>
            {
                if (movement != null)
                {
                    Console.WriteLine($"Dashboard updated at {movement.Timestamp} for {movement.Symbol}: " +
                    $"{movement.PriceChange * 100:F2}% change, " +
                    $"from {movement.StartPrice} to {movement.EndPrice}");
                }
            });
        }
    }
}
