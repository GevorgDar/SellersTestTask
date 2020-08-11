using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SellerCell : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rating;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI type;
    [SerializeField] private TextMeshProUGUI gold;

    public void SetValues(string rating, string name, string type, string gold)
    {
        this.rating.text = rating;
        this.name.text = name;
        this.type.text = type;
        this.gold.text = gold;
    }
}
