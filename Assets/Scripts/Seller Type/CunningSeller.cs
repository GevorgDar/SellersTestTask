// ушлый - Всегда начинает с последовательности ходов: сотрудничество, жульничество, сотрудничество, сотрудничество.
// Далее, если к пятому ходу его хоть раз обманули, то играет как кидала, если нет, то как хитрец.
public class CunningSeller : Seller
{
    private int dealsАtТhisМoment = 0;
    private bool wasDeceived = false;

    public CunningSeller(string name)
    {
        sellerName = name;
        sellerType = SellerType.Cunning;
        behaviour = SellerBehaviour.Cooperate;
    }

    public override void TypeOfThinking(SellerBehaviour partnerBehavior)
    {

        if (dealsАtТhisМoment >= 4)
        {
            if (wasDeceived)
            {
                behaviour = SellerBehaviour.Cheat;
            }
            else
            {
                behaviour = partnerBehavior;
            }
        }
        else
        {
            dealsАtТhisМoment++;

            if (partnerBehavior == SellerBehaviour.Cheat)
            {
                wasDeceived = true;
            }

            if (dealsАtТhisМoment == 2)
            {
                behaviour = SellerBehaviour.Cheat;
            }
            else
            {
                behaviour = SellerBehaviour.Cooperate;
            }
        }
    }
}