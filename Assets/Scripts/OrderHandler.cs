using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text orderName;
    
    [SerializeField]
    private TMP_Text price;

    [SerializeField]
    private InputField adresse;


    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => { PlaceOrder(orderName.text, adresse.text, price.text); });
    }

    public void PlaceOrder(string name, string adresse, string price) 
    {
        DataSync.DefaultInstance.DownloadPastOrdersData();

        Order newOrder = new Order();

        newOrder.orderName = name;

        newOrder.price = price;

        newOrder.shippingAdresse = adresse;

        DataSync.DefaultInstance.ordersData.orders.Add(newOrder);

        DataSync.DefaultInstance.UploadPastOrdersData();
    }
}
