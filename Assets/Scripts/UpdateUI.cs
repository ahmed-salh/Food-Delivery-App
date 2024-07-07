using TMPro;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text firstName;

    [SerializeField]
    private GameObject orderItem;

    [SerializeField]
    private Transform parent;

    [SerializeField]
    private PastOrdersController pastOrderController;

    public void UpdateName()
    {
        firstName.text = DataSync.DefaultInstance.userData.CurrentUser.firstName;
    }

    public void UpdatePastOrders()
    {
        pastOrderController.ClearPastOrders();

        for (int i = 0; i < DataSync.DefaultInstance.ordersData.orders.Count; i++)
        {

            GameObject newOrder = Instantiate(orderItem, parent);

            OrderDetails newOrderDetails = newOrder.GetComponent<OrderDetails>();

            newOrderDetails.OrderName = DataSync.DefaultInstance.ordersData.orders[i].orderName;

            newOrderDetails.Price = DataSync.DefaultInstance.ordersData.orders[i].price;

            newOrderDetails.ShippingAdresse = DataSync.DefaultInstance.ordersData.orders[i].shippingAdresse;

        }
    }
}
