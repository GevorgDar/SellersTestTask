using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class Gameplay : MonoBehaviour
{
    public static Gameplay current;
    public event Action<List<Seller>> arrangedSellerList;
    // TODO: - set max sellers, and last update sellers count in unity
    private List<Seller> _sellers;
    private Dealmaker _dealmaker;
    private bool _firstYear = true;

    private void Awake()
    {
        current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _dealmaker = new Dealmaker();
        List<SellerType> sellerTypes = new List<SellerType>(){
                                            SellerType.Altruist,
                                            SellerType.Cunning,
                                            SellerType.Liar,
                                            SellerType.Sly,
                                            SellerType.Unpredictable,
                                            SellerType.Vindictive};

        _sellers = PrimordialInitializationSeller(60, sellerTypes);
        arrangedSellerList(_sellers);
    }

    public void OneYearLater()
    {
        if (_firstYear)
            _firstYear = false;
        else
            RefreshSellersList(sellers: _sellers, lastSellers: 20);

        for (int first = 0; first < _sellers.Count; first++)
        {
            for (int second = first + 1; second < _sellers.Count; second++)
            {
                _dealmaker.MakeADeals(_sellers[first], _sellers[second]);
            }
        }
        //сортировка по золото
        _sellers = _sellers.OrderByDescending(x => x.SellerCurrentYearOlds()).ToList();

        arrangedSellerList(_sellers);
    }

    private void RefreshSellersList(List<Seller> sellers, int lastSellers)
    {
        int topSellers = 0;

        for (int i = sellers.Count - 1; i >= sellers.Count - lastSellers; i--)
        {
            sellers[i] = SellerCreator.Singltone.create(sellers[topSellers].SellerType);
            topSellers++;
        }

        for (int i = 0; i < sellers.Count; i++)
        {
            //обнуление годового дохода
            sellers[i].zeroingAnnualIncome();
        }
    }

    //Изначально в Гильдии состоит равное число торговцев, выступающих приверженцами каждой из перечисленных стратегий.
    private List<Seller> PrimordialInitializationSeller(int count, List<SellerType> sellerTypes)
    {
        List<Seller> sellers = new List<Seller>();
        int sellersTypesCount = sellerTypes.Count;
        //сколько должно быть из каждого
        int countOfEach = count / sellersTypesCount;

        for (int i = 0; i < sellersTypesCount; i++)
        {
            for (int j = countOfEach * i; j < countOfEach * (i + 1) ; j++)
            {
                sellers.Add(SellerCreator.Singltone.create(sellerTypes[i]));    
            }
        }

        return sellers;
    }
}