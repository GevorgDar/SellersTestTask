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
    // TODO: - create random name List, and detele static counts...
    private static int altruistCount = 1;
    private static int liarCount = 1;
    private static int slyCount = 1;
    private static int unpredictableCount = 1;
    private static int vindictiveCount = 1;
    private static int cunningCount = 1;

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

    public static Seller create(SellerType sellerType)
    {
        switch (sellerType)
        {

            case SellerType.Altruist:
                return new AltruistSeller("Altruist " + altruistCount);
            case SellerType.Liar:
                return new LiarSeller("Liar " + liarCount);
            case SellerType.Sly:
                return new SlySeller("Sly " + slyCount);
            case SellerType.Unpredictable:
                return new UnpredictableSeller("Unpredictable " + unpredictableCount);
            case SellerType.Vindictive:
                return new VindictiveSeller("Vindictive " + vindictiveCount);
            case SellerType.Cunning:
                return new CunningSeller("Cunning " + cunningCount);
        }

        return null;
    }
}