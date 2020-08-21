// альтруист - Всегда сотрудничает.
public class AltruistSeller : Seller
{
    public AltruistSeller(string name)
    {
        sellerName = name;
        sellerType = SellerType.Altruist;
        behaviour = SellerBehaviour.Cooperate;
    }

    public override void TypeOfThinking(SellerBehaviour partnerBehavior)
    {
        behaviour = SellerBehaviour.Cooperate;
    }
}