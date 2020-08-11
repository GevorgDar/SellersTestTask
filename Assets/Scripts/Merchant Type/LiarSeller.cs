// кидала - Всегда жульничает.
public class LiarSeller : Seller
{
    public LiarSeller(string name)
    {
        sellerName = name;
        sellerType = SellerType.Liar;
        behaviour = SellerBehaviour.Cheat;
    }

    public override void TypeOfThinking(SellerBehaviour partnerBehavior)
    {
        behaviour = SellerBehaviour.Cheat;
    }
}