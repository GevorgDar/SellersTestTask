public enum SellerBehaviour
{
    Cooperate,
    Cheat
}

public enum SellerType
{
    Altruist,
    Liar,
    Sly,
    Unpredictable,
    Vindictive,
    Cunning
}

public abstract class Seller
{
    protected SellerBehaviour behaviour;
    protected SellerType sellerType;
    protected string sellerName;
    protected int dealCount;
    protected int currentYearOlds;
    protected int gold;

    public abstract void TypeOfThinking(SellerBehaviour partnerBehavior);

    public void zeroingAnnualIncome()
    {
        currentYearOlds = 0;
    }

    public void IncomeGeneration(int income)
    {
        currentYearOlds += income;
        gold += income;
        dealCount++;
    }
    
    public string SellerName()
    {
        return sellerName;
    }

    public int SellerCurrentYearOlds()
    {
        return currentYearOlds;
    }

    public int SellerGold()
    {
        return gold;
    }

    public int SellerDealCount()
    {
        return dealCount;
    }

    public SellerBehaviour Behaviour
    {
        get
        {
            return behaviour;
        }
    }

    public SellerType SellerType
    {
        get
        {
            return sellerType;
        }
    }
}