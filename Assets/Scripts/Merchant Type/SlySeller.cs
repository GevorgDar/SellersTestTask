// хитрец - Начинает с сотрудничества, потом повторяет ход оппонента
public class SlySeller : Seller
{
    public SlySeller(string name)
    {
        sellerName = name;
        sellerType = SellerType.Sly;
        behaviour = SellerBehaviour.Cooperate;
    }

    public override void TypeOfThinking(SellerBehaviour partnerBehavior)
    {
        behaviour = partnerBehavior;
    }
}