using System.Diagnostics;
using AsyncPlayground.Services;

namespace AsyncPlayground;

class Program
{
    static async Task Main(string[] args)
    {
        var syncPricingService = new SyncPricingService();
        var syncFee = syncPricingService.CalculateFees();
        Console.WriteLine($"sync fee: {syncFee}");
        
        Console.WriteLine("---------------------------------------------------");
        var asyncPricingService = new AsyncPricingService();
        var asyncFee = await asyncPricingService.CalculateFeesAsync();
        Console.WriteLine($"async fee: {asyncFee}");
        
        Console.WriteLine("---------------------------------------------------");
        var awaitFee = await asyncPricingService.CalculateFeesAsyncAwait();
        Console.WriteLine($"await fee: {awaitFee}");
    }
}