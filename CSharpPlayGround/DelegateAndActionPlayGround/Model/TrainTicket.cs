namespace DelegateAndActionPlayGround.Model;

public class TrainTicket
{
    public string TicketId { get; }
    public decimal Price { get; set; }      // base + add-ons
    public decimal Discount { get; set; }   // from promo
    public List<string> Extras { get; } = new();

    public decimal FinalPrice => Price - Discount;

    public TrainTicket(string ticketId, decimal basePrice)
    {
        TicketId = ticketId;
        Price = basePrice;
    }
}