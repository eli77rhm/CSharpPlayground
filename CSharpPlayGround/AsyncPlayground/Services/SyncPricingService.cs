using System.Diagnostics;

namespace AsyncPlayground.Services;

public class SyncPricingService
{
    public int CalculateFees()
    {
        var watch = Stopwatch.StartNew();
        
       var  ticketFee = GetTicketPrice();
       var insurranceFee = GetInsurrancePrice();
       var vatFee = CalculateVat();
       var adminFee = CalculateAdminFee();
       
       var fees = new[] { ticketFee, insurranceFee, vatFee, adminFee }; 
       
       watch.Stop();
       Console.WriteLine($"Total time <CalculateFees>: {watch.ElapsedMilliseconds}ms");
       
       

        return fees.Sum();
    }

    private int GetTicketPrice()
    {
        Console.WriteLine($" getting Ticket Price at {DateTime.Now}");
        Thread.Sleep(TimeSpan.FromSeconds(1));
        return 20;
    }
    
    private int GetInsurrancePrice()
    {
        Console.WriteLine($" getting Insurrance Price at {DateTime.Now}");
        Thread.Sleep(TimeSpan.FromSeconds(2));
        return 5;
    }
    
    private int CalculateVat()
    {
        Console.WriteLine($" Calculating Vat at {DateTime.Now}");
        Thread.Sleep(TimeSpan.FromSeconds(10));
        return 1;
    }
    
    private int CalculateAdminFee()
    {
        Console.WriteLine($" Calculating Admin fee at {DateTime.Now}");
        Thread.Sleep(TimeSpan.FromSeconds(3));
        return 2;
    }
}