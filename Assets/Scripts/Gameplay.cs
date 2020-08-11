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
    private List<Seller> sellers;
    private Dealmaker dealmaker;
    private bool firstYear = true;

    private void Awake()
    {
        current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        dealmaker = new Dealmaker();
        sellers = PrimordialInitializationSeller();
        arrangedSellerList(sellers);
    }

    public void OneYearLater()
    {
        if (firstYear)
            firstYear = false;
        else
            RefreshSellersList(sellers: sellers, lastSellers: 20);

        for (int first = 0; first < sellers.Count; first++)
        {
            for (int second = first + 1; second < sellers.Count; second++)
            {
                dealmaker.MakeADeals(sellers[first], sellers[second]);
            }
        }
        //сортировка по золото
        sellers = sellers.OrderByDescending(x => x.SellerCurrentYearOlds()).ToList();

        arrangedSellerList(sellers);
    }

    private void RefreshSellersList(List<Seller> sellers, int lastSellers)
    {
        int topSellers = 0;

        for (int i = sellers.Count - 1; i >= sellers.Count - lastSellers; i--)
        {
            sellers[i] = Seller.create(sellers[topSellers].SellerType);
            topSellers++;
        }

        for (int i = 0; i < sellers.Count; i++)
        {
            //обнуление годового дохода
            sellers[i].zeroingAnnualIncome();
        }
    }

    //Изначально в Гильдии состоит равное число торговцев, выступающих приверженцами каждой из перечисленных стратегий.
    private List<Seller> PrimordialInitializationSeller()
    {
        List<Seller> sellers = new List<Seller>();
    
        for (int i = 0; i < 60; i++)
        {
            if (i < 10)
            {
                sellers.Add(Seller.create(SellerType.Altruist));
            }
            else if (i < 20)
            {
                sellers.Add(Seller.create(SellerType.Liar));
            }
            else if (i < 30)
            {
                sellers.Add(Seller.create(SellerType.Sly));
            }
            else if (i < 40)
            {
                sellers.Add(Seller.create(SellerType.Unpredictable));
            }
            else if (i < 50)
            {
                sellers.Add(Seller.create(SellerType.Vindictive));
            }
            else
            {
                sellers.Add(Seller.create(SellerType.Cunning));
            }
        }

        return sellers;
    }
}