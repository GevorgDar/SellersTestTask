using UnityEngine;

//В процессе сделки для каждого торговца существует 5% вероятность ошибиться и принять неправильное решение:
//сжульничать вместо того, чтобы сотрудничать, или наоборот.

//в том случае, если оба проводят сделку честно, оба зарабатывают по 4 золотых;
//если один торговец сжульничает, а другой продолжит честно сотрудничать, то жулик получит 5 золотых, а честный торогвец - всего 1;
//если оба сжульничают, то каждый получит только по 2 золотых.

public class Dealmaker
{
    private int dealsCount;
    private Seller firstSeller;
    private Seller secondSeller;
    //поведение в текущем сделке
    private SellerBehaviour firstSellerBehaviour;
    private SellerBehaviour secondSellerBehaviour;

    public void MakeADeals(Seller first, Seller second)
    {
        //5 до 10 сделок между каждой парой торговцев
        dealsCount = Random.Range(5, 10);
        firstSeller = first;
        secondSeller = second;
        firstSellerBehaviour = first.Behaviour;
        secondSellerBehaviour = second.Behaviour;

        for (int i = 0; i < dealsCount; i++)
        {
            ErrorProbability();
            Calculation();
        }
    }

    private void Calculation()
    {
        if (firstSellerBehaviour == SellerBehaviour.Cheat && secondSellerBehaviour == SellerBehaviour.Cheat)
        {
            //оба сжульничают
            firstSeller.IncomeGeneration(2);
            secondSeller.IncomeGeneration(2);
        }
        else if (firstSellerBehaviour == SellerBehaviour.Cooperate && secondSellerBehaviour == SellerBehaviour.Cooperate)
        {
            //оба проводят сделку честно
            firstSeller.IncomeGeneration(4);
            secondSeller.IncomeGeneration(4);
        }
        else if (firstSellerBehaviour == SellerBehaviour.Cheat && secondSellerBehaviour == SellerBehaviour.Cooperate)
        {
            //первый торговец жулик, а втарой честный
            firstSeller.IncomeGeneration(5);
            secondSeller.IncomeGeneration(1);
        }
        else
        {
            //первый торговец честный, а втарой жулик
            firstSeller.IncomeGeneration(1);
            secondSeller.IncomeGeneration(5);
        }

        RefreshThinking();
    }

    private void RefreshThinking()
    {
        firstSeller.TypeOfThinking(partnerBehavior: secondSellerBehaviour);
        secondSeller.TypeOfThinking(partnerBehavior: firstSellerBehaviour);

        firstSellerBehaviour = firstSeller.Behaviour;
        secondSellerBehaviour = secondSeller.Behaviour;
    }

    //В процессе сделки для каждого торговца существует 5% вероятность ошибиться и принять неправильное решение
    private void ErrorProbability()
    {
        if (Random.Range(1, 100) > 95)
        {
            if (firstSellerBehaviour == SellerBehaviour.Cheat)
            {
                firstSellerBehaviour = SellerBehaviour.Cooperate;
            }
            else
            {
                firstSellerBehaviour = SellerBehaviour.Cheat;
            }
        }

        if (Random.Range(1, 100) > 95)
        {
            if (secondSellerBehaviour == SellerBehaviour.Cheat)
            {
                secondSellerBehaviour = SellerBehaviour.Cooperate;
            }
            else
            {
                secondSellerBehaviour = SellerBehaviour.Cheat;
            }
        }
    }
}