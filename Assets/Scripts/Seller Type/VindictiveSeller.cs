// злопамятный - Начинает с сотрудничества и продолжает сотрудничать,
// пока против него не сжульничают. После этого сам начинает постоянно жульничать.
public class VindictiveSeller : Seller
{
    public VindictiveSeller(string name)
    {
        sellerName = name;
        sellerType = SellerType.Vindictive;
        behaviour = SellerBehaviour.Cooperate;
    }

    public override void TypeOfThinking(SellerBehaviour partnerBehavior)
    {
        if (partnerBehavior == SellerBehaviour.Cheat && behaviour == SellerBehaviour.Cooperate)
        {
            behaviour = SellerBehaviour.Cheat;
        }
    }
}