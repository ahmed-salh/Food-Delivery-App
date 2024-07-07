using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastOrdersController : MonoBehaviour
{
    public void ClearPastOrders()
    {
        
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
