using DelegateAndActionPlayGround.Model;
using DelegateAndActionPlayGround.Promos;

namespace DelegateAndActionPlayGround.Services;

public  delegate decimal PromoRuleDelegate(decimal price);

public static class PromoService
{
    public static TrainTicket ApplyPromoWithDelegate(TrainTicket ticket, string? promoCode)
    {
         var promoRule = promoRuleMethod(promoCode);
        ticket.Discount = promoRule(ticket.Price);
        return ticket;
    }
    
    public static PromoRuleDelegate  promoRuleMethod(string? promoCode)
    {
        switch (promoCode.Trim().ToUpperInvariant())
        {
            case "TENOFF": // flat £10 off, capped by price
                return PromoRules.TenOff;
            case "HALF":   // 50% off
                return PromoRules.HalfOff;
            case "LOYAL":  // 5% off, max £5
                return PromoRules.LoyalCap;
            default:
                // unknown code -> no discount
                return price => 0m;
        }
    }
    public static TrainTicket ApplyPromo(TrainTicket ticket, string? promoCode)
    {
        ticket.Discount = 0m;
        if (string.IsNullOrWhiteSpace(promoCode)) return ticket;

        switch (promoCode.Trim().ToUpperInvariant())
        {
            case "TENOFF": // flat £10 off, capped by price
                ticket.Discount = PromoRules.TenOff(ticket.Price);
                break;
            case "HALF":   // 50% off
                ticket.Discount = PromoRules.HalfOff(ticket.Price);
                break;
            case "LOYAL":  // 5% off, max £5
                ticket.Discount = PromoRules.LoyalCap(ticket.Price);
                break;
            default:
                // unknown code -> no discount
                break;
        }

        return ticket;
    }
}