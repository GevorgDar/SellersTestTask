using System;

// непредсказуемый - Поступает случайным образом.
public class UnpredictableSeller : Seller
{
    public UnpredictableSeller(string name)
    {
        sellerName = name;
        sellerType = SellerType.Unpredictable;
        behaviour = GetRandomBehavior();
    }

    public override void TypeOfThinking(SellerBehaviour partnerBehavior)
    {
        behaviour = GetRandomBehavior();
    }

    private SellerBehaviour GetRandomBehavior()
    {
        Array behaviours = Enum.GetValues(typeof(SellerBehaviour));
        Random random = new Random();
        SellerBehaviour randomBehaviour = (SellerBehaviour)behaviours.GetValue(random.Next(behaviours.Length));

        return randomBehaviour;
    }
}