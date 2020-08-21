using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _sellerCell;
    [SerializeField] private GameObject _scrollViewContent;
    private List<GameObject> _sellerCells = new List<GameObject>();

    private void OnEnable() => Gameplay.current.arrangedSellerList += UpdateSellerRating;
    private void OnDestroy() => Gameplay.current.arrangedSellerList -= UpdateSellerRating;

    private void UpdateSellerRating(List<Seller> sellers)
    {
        for (int i = 0; i < sellers.Count; i++)
        {
            if (_sellerCells.Count - 1 >= i)
            {
                _sellerCells[i].SetActive(true);
                SellerCell cell = _sellerCells[i].GetComponent<SellerCell>();
                cell.SetValues(rating: (i + 1).ToString(),
                               name: sellers[i].SellerName(),
                               type: sellers[i].SellerType.ToString(),
                               gold: sellers[i].SellerCurrentYearOlds().ToString());
            }
            else
            {
                GameObject sellerCellobject = Instantiate(_sellerCell);
                SellerCell cell = sellerCellobject.GetComponent<SellerCell>();
                cell.SetValues(rating: (i + 1).ToString(),
                               name: sellers[i].SellerName(),
                               type: sellers[i].SellerType.ToString(),
                               gold: sellers[i].SellerCurrentYearOlds().ToString());
                _sellerCells.Add(sellerCellobject);
            }

            _sellerCells[i].transform.parent = _scrollViewContent.transform;
        }

        for (int i = sellers.Count; i < _sellerCells.Count; i++)
        {
            _sellerCells[i].SetActive(false);
        }
    }
}