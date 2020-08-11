using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject sellerCell;
    [SerializeField] private GameObject scrollViewContent;
    private List<GameObject> sellerCells = new List<GameObject>();

    public void Start()
    {
        Gameplay.current.arrangedSellerList += UpdateSellerRating;
    }

    private void UpdateSellerRating(List<Seller> sellers)
    {
        for (int i = 0; i < sellers.Count; i++)
        {
            if (sellerCells.Count - 1 >= i)
            {
                sellerCells[i].SetActive(true);
                SellerCell cell = sellerCells[i].GetComponent<SellerCell>();
                cell.SetValues(rating: (i + 1).ToString(),
                               name: sellers[i].SellerName(),
                               type: sellers[i].SellerType.ToString(),
                               gold: sellers[i].SellerCurrentYearOlds().ToString());
            }
            else
            {
                GameObject sellerCellobject = Instantiate(sellerCell);
                SellerCell cell = sellerCellobject.GetComponent<SellerCell>();
                cell.SetValues(rating: (i + 1).ToString(),
                               name: sellers[i].SellerName(),
                               type: sellers[i].SellerType.ToString(),
                               gold: sellers[i].SellerCurrentYearOlds().ToString());
                sellerCells.Add(sellerCellobject);
            }

            sellerCells[i].transform.parent = scrollViewContent.transform;
        }

        for (int i = sellers.Count; i < sellerCells.Count; i++)
        {
            sellerCells[i].SetActive(false);
        }
    }

    private void OnDestroy()
    {
        Gameplay.current.arrangedSellerList -= UpdateSellerRating;
    }
}
