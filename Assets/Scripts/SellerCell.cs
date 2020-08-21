using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SellerCell : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _rating;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _type;
    [SerializeField] private TextMeshProUGUI _gold;

    public void SetValues(string rating, string name, string type, string gold)
    {
        _rating.text = rating;
        _name.text = name;
        _type.text = type;
        _gold.text = gold;
    }
}
