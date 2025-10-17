using DelegateAndActionPlayGround.Model;

namespace DelegateAndActionPlayGround.AddOns;

public static class TrainAddOns
{
    public static void AddInsurance(TrainTicket ticket)
    {
        ticket.Price += 7m; 
        ticket.Extras.Add("Insurance");
    }

    public static void CoffeeToSeat(TrainTicket ticket)
    {
        ticket.Price += 3m;
        ticket.Extras.Add("Coffee to seat");
    }

    public static void FoodDelivery(TrainTicket ticket)
    {
        ticket.Price += 8m; 
        ticket.Extras.Add("Food delivered to seat");
    }

    public static void ExtraLegroom(TrainTicket ticket)
    {
        ticket.Price += 12m;
        ticket.Extras.Add("Extra legroom");
    }
}