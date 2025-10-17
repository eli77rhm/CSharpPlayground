using DelegateAndActionPlayGround.AddOns;
using DelegateAndActionPlayGround.Model;
using DelegateAndActionPlayGround.Services;

namespace DelegateAndActionPlayGround;

class Program
{
    static void Main(string[] args)
    {
        
        var ticket = new TrainTicket("T123", 50m);
        var listOfAddOns = new List<Action<TrainTicket>>
        {
            TrainAddOns.AddInsurance,
            TrainAddOns.CoffeeToSeat,
            TrainAddOns.FoodDelivery
        };
        ticket = AddOnService.ApplyAddOnsWithAction(ticket,listOfAddOns);
        // ticket = AddOnService.ApplyAddOns(ticket, new List<string> { "insurance", "coffee", "food" });
        ticket = PromoService.ApplyPromoWithDelegate(ticket, "TENOFF");
        // ticket = PromoService.ApplyPromo(ticket, "TENOFF");
        
        
        Console.WriteLine("Ticket ID: " + ticket.TicketId);
        Console.WriteLine("Base Price + Add-Ons: " + ticket.Price);
        Console.WriteLine("Discount: " + ticket.Discount);
        Console.WriteLine("Final Price: " + ticket.FinalPrice);
        Console.WriteLine("Extras: " + string.Join(", ", ticket.Extras));
    }
}