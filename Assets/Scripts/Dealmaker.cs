using UnityEngine;

//В процессе сделки для каждого торговца существует 5% вероятность ошибиться и принять неправильное решение:
//сжульничать вместо того, чтобы сотрудничать, или наоборот.

//в том случае, если оба проводят сделку честно, оба зарабатывают по 4 золотых;
//если один торговец сжульничает, а другой продолжит честно сотрудничать, то жулик получит 5 золотых, а честный торогвец - всего 1;
//если оба сжульничают, то каждый получит только по 2 золотых.

public class Dealmaker
{
    private int _dealsCount;
    private Seller _firstSeller;
    private Seller _secondSeller;
    //поведение в текущем сделке
    private SellerBehaviour _firstSellerBehaviour;
    private SellerBehaviour _secondSellerBehaviour;

    public void MakeADeals(Seller first, Seller second)
    {
        //5 до 10 сделок между каждой парой торговцев
        _dealsCount = Random.Range(5, 10);
        _firstSeller = first;
        _secondSeller = second;
        _firstSellerBehaviour = first.Behaviour;
        _secondSellerBehaviour = second.Behaviour;

        for (int i = 0; i < _dealsCount; i++)
        {
            ErrorProbability();
            Calculation();
        }
    }

    private void Calculation()
    {
        if (_firstSellerBehaviour == SellerBehaviour.Cheat && _secondSellerBehaviour == SellerBehaviour.Cheat)
        {
            //оба сжульничают
            _firstSeller.IncomeGeneration(2);
            _secondSeller.IncomeGeneration(2);
        }
        else if (_firstSellerBehaviour == SellerBehaviour.Cooperate && _secondSellerBehaviour == SellerBehaviour.Cooperate)
        {
            //оба проводят сделку честно
            _firstSeller.IncomeGeneration(4);
            _secondSeller.IncomeGeneration(4);
        }
        else if (_firstSellerBehaviour == SellerBehaviour.Cheat && _secondSellerBehaviour == SellerBehaviour.Cooperate)
        {
            //первый торговец жулик, а втарой честный
            _firstSeller.IncomeGeneration(5);
            _secondSeller.IncomeGeneration(1);
        }
        else
        {
            //первый торговец честный, а втарой жулик
            _firstSeller.IncomeGeneration(1);
            _secondSeller.IncomeGeneration(5);
        }

        RefreshThinking();
    }

    private void RefreshThinking()
    {
        _firstSeller.TypeOfThinking(partnerBehavior: _secondSellerBehaviour);
        _secondSeller.TypeOfThinking(partnerBehavior: _firstSellerBehaviour);

        _firstSellerBehaviour = _firstSeller.Behaviour;
        _secondSellerBehaviour = _secondSeller.Behaviour;
    }

    //В процессе сделки для каждого торговца существует 5% вероятность ошибиться и принять неправильное решение
    private void ErrorProbability()
    {
        if (Random.Range(1, 100) > 95)
        {
            if (_firstSellerBehaviour == SellerBehaviour.Cheat)
            {
                _firstSellerBehaviour = SellerBehaviour.Cooperate;
            }
            else
            {
                _firstSellerBehaviour = SellerBehaviour.Cheat;
            }
        }

        if (Random.Range(1, 100) > 95)
        {
            if (_secondSellerBehaviour == SellerBehaviour.Cheat)
            {
                _secondSellerBehaviour = SellerBehaviour.Cooperate;
            }
            else
            {
                _secondSellerBehaviour = SellerBehaviour.Cheat;
            }
        }
    }
}