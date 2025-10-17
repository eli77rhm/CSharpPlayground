using DelegateAndActionPlayGround.AddOns;
using DelegateAndActionPlayGround.Model;

namespace DelegateAndActionPlayGround.Services;

public static class AddOnService
{
    public  static TrainTicket ApplyAddOns(TrainTicket ticket, IEnumerable<string> addOns)
    {
        foreach (var raw in addOns)
        {
            if (string.IsNullOrWhiteSpace(raw)) continue;
            var name = raw.Trim().ToLowerInvariant();

            switch (name)
            {
                case "insurance":
                {
                    TrainAddOns.AddInsurance(ticket);
                    break;
                }
                case "coffee":
                {
                    TrainAddOns.CoffeeToSeat(ticket);
                    break;
                }
                case "food":
                {
                    TrainAddOns.FoodDelivery(ticket);
                    break;
                }
            }
        }
        return ticket;
    }
    
    public  static TrainTicket ApplyAddOnWithAction(TrainTicket ticket, Action<TrainTicket> addOnAction)
    {
        addOnAction(ticket);
        return ticket;
    }
    
    public  static TrainTicket ApplyAddOnsWithAction(TrainTicket ticket, List<Action<TrainTicket>> addOnActions)
    {
        foreach (var addOnAction in addOnActions)
        {
            addOnAction(ticket);
        }
        return ticket;
    }
}