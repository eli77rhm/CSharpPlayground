namespace DelegateAndActionPlayGround.Promos;

public static class PromoRules
{
    public static decimal TenOff(decimal price)
    {
        return Math.Min(10m, price);
    }
    public static decimal HalfOff(decimal price)
    {
        return price * 0.50m;
    } 
    public static decimal LoyalCap(decimal price)
    {
        return Math.Min(price * 0.05m, 5m);
    }
}