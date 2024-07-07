using TMPro;
using UnityEngine;

public class OrderDetails : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _orderName;

    [SerializeField]
    private TMP_Text _shippingAdresse;

    [SerializeField]
    private TMP_Text _price;

    public string OrderName 
    {
        set { _orderName.text = value; }
    }

    public string ShippingAdresse
    {
        set { _shippingAdresse.text = "Adresse : " + value; }
    }

    public string Price
    {
        set { _price.text = "Price : " + value; }
    }
}
