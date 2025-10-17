using DelegateAndActionPlayGround.Services;
using DelegateAndActionPlayGround.Model;

namespace DelegateAndActionPlayGround.Tests;

public class BasicPipelineTests
{
    [Test]
    public void Basic_AddOns_Then_Promo_Works()
    {
        var ticket = new TrainTicket("TK-001", 50m);

        // add-ons first
        AddOnService.ApplyAddOns(ticket, new[] { "Insurance", "Coffee" });

        // promo second
        PromoService.ApplyPromo(ticket, "TENOFF");

        Assert.That(ticket.Price, Is.EqualTo(60m));        // 50 + 7 + 3
        Assert.That(ticket.Discount, Is.EqualTo(10m));     // TENOFF -10
        Assert.That(ticket.FinalPrice, Is.EqualTo(50m));
        Assert.That(ticket.Extras, Has.Count.EqualTo(2));
    }

    [Test]
    public void Unknown_AddOn_And_Unknown_Promo_Do_Nothing()
    {
        var ticket = new TrainTicket("TK-002", 40m);

        AddOnService.ApplyAddOns(ticket, new[] { "unknown-addon" });
        PromoService.ApplyPromo(ticket, "???" );

        Assert.That(ticket.Price, Is.EqualTo(40m));
        Assert.That(ticket.Discount, Is.EqualTo(0m));
        Assert.That(ticket.FinalPrice, Is.EqualTo(40m));
        Assert.That(ticket.Extras, Is.Empty);
    }
}