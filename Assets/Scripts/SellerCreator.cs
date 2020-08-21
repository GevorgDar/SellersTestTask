using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SellerCreator
{
    private static SellerCreator _instance;
    private int _altruistCount = 0;
    private int _liarCount = 0;
    private int _slyCount = 0;
    private int _unpredictableCount = 0;
    private int _vindictiveCount = 0;
    private int _cunningCount = 0;


    public static SellerCreator Singltone
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SellerCreator();
            }
            return _instance;
        }
    }

    public Seller create(SellerType sellerType)
    {
        switch (sellerType)
        {

            case SellerType.Altruist:
                return new AltruistSeller("Altruist " + ++_altruistCount);
            case SellerType.Liar:
                return new LiarSeller("Liar " + ++_liarCount);
            case SellerType.Sly:
                return new SlySeller("Sly " + ++_slyCount);
            case SellerType.Unpredictable:
                return new UnpredictableSeller("Unpredictable " + ++_unpredictableCount);
            case SellerType.Vindictive:
                return new VindictiveSeller("Vindictive " + ++_vindictiveCount);
            case SellerType.Cunning:
                return new CunningSeller("Cunning " + ++_cunningCount);
        }

        return null;
    }
}
