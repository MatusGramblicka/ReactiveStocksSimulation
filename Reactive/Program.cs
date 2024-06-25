using Reactive;

// https://medium.com/codenx/reactive-systems-in-c-net-5aba12d087e0

var significantMovements = StockAnalysis.AnalyzeStockTicks();
var _ = new SignificantMovementActor(significantMovements);

Console.WriteLine("System is running. Press any key to exit...");
Console.ReadLine();
