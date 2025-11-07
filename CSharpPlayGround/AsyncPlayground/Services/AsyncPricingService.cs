using System.Diagnostics;

namespace AsyncPlayground.Services;

public class AsyncPricingService
{
    public async Task<int> CalculateFeesAsync()
    {
        var watch = Stopwatch.StartNew();
        
        var  ticketFeeTask = GetTicketPriceAsync();
        var insurranceFeeTask =  GetInsurrancePriceAsync();
        var vatFeeTask = CalculateVatAsync();
        var adminFeeTask = CalculateAdminFeeAsync();
        
        var fees = await Task.WhenAll( ticketFeeTask, insurranceFeeTask, vatFeeTask, adminFeeTask );
        
        watch.Stop();
        Console.WriteLine($"Total time <CalculateFeesAsync>: {watch.ElapsedMilliseconds}ms");

        

        return fees.Sum();
    }
    
    public async Task<int> CalculateFeesAsyncAwait()
    {
        var watch = Stopwatch.StartNew();
        
        var  ticketFee = await GetTicketPriceAsync();
        var insurranceFee = await  GetInsurrancePriceAsync();
        var vatFee= await CalculateVatAsync();
        var adminFee = await CalculateAdminFeeAsync();
        
        var fees = new[] { ticketFee, insurranceFee, vatFee, adminFee }; 
        
        watch.Stop();
        Console.WriteLine($"Total time <CalculateFeesAwait>: {watch.ElapsedMilliseconds}ms");

        

        return fees.Sum();
    }

    private async Task<int> GetTicketPriceAsync()
    {
        Console.WriteLine($" getting Ticket Price at {DateTime.Now}");
        await Task.Delay( TimeSpan.FromSeconds(1));
        return 20;
    }
    
    private async Task<int> GetInsurrancePriceAsync()
    {
        Console.WriteLine($" getting Insurrance Price at {DateTime.Now}");
        await Task.Delay( TimeSpan.FromSeconds(2));
        return 5;
    }
    
    private async Task<int> CalculateVatAsync()
    {
        Console.WriteLine($" Calculating Vat at {DateTime.Now}");
        await Task.Delay( TimeSpan.FromSeconds(10));
        return 1;
    }
    
    private async Task<int> CalculateAdminFeeAsync()
    {
        Console.WriteLine($" Calculating Admin fee at {DateTime.Now}");
        await Task.Delay( TimeSpan.FromSeconds(3));
        return 2;
    }
}