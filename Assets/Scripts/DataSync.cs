using Firebase.Database;
using System.Collections;
using UnityEngine;
using Newtonsoft.Json;
using Firebase.Auth;
using System.Collections.Generic;

public class DataSync : MonoBehaviour
{
    public static DataSync DefaultInstance;

    public DatabaseReference databaseRef;

    public UserData userData;

    public PastOrders ordersData;

    [SerializeField]
    private UpdateUI updateUI;

    private void Awake()
    {
        databaseRef = FirebaseDatabase.GetInstance("https://universityprojects-eedf6-default-rtdb.firebaseio.com/").RootReference;

        DefaultInstance = this;

        userData = new UserData();

        ordersData = new PastOrders();

        ordersData.orders = new List<Order>();
    }

    public void UploadUserData(UserData Data)
    {
        string json = JsonConvert.SerializeObject(Data);

        string UserID = FirebaseAuth.DefaultInstance.CurrentUser.UserId;

        databaseRef.Child("Users").Child(UserID).SetRawJsonValueAsync(json);

        Debug.Log(json);
    }

    public void UploadPastOrdersData()
    {
        string json = JsonConvert.SerializeObject(ordersData);

        string UserID = FirebaseAuth.DefaultInstance.CurrentUser.UserId;

        databaseRef.Child("PastOrders").Child(UserID).SetRawJsonValueAsync(json);
    }

    public void DownloadUserData()
    {
        StartCoroutine(DownloadUserDataEnum());
    }

    private IEnumerator DownloadUserDataEnum()
    {
        var serverData = databaseRef.Child("Users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).GetValueAsync();

        yield return new WaitUntil(predicate: () => serverData.IsCompleted);

        DataSnapshot snapshot = serverData.Result;

        string jsonData = snapshot.GetRawJsonValue();

        if (jsonData != null)
        {
            userData = JsonConvert.DeserializeObject<UserData>(jsonData);
        }
        else
        {
            Debug.Log("No data has been found!");
        }

        updateUI.UpdateName();
    }

    public void DownloadPastOrdersData()
    {
        StartCoroutine(DownloadPastOrdersDataEnum());
    }

    private IEnumerator DownloadPastOrdersDataEnum()
    {
        var serverData = databaseRef.Child("PastOrders").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).GetValueAsync();

        yield return new WaitUntil(predicate: () => serverData.IsCompleted);

        DataSnapshot snapshot = serverData.Result;

        string jsonData = snapshot.GetRawJsonValue();

        if (jsonData != null)
        {

            ordersData = JsonConvert.DeserializeObject<PastOrders>(jsonData);
        }
        else
        {
            Debug.Log("No data has been found!");
        }

        updateUI.UpdatePastOrders();
    }
}

public class UserData 
{
    public User CurrentUser;
}

public class User 
{
    public string firstName;

    public string lastName;

    public string phoneNo;
}

public class PastOrders 
{
    public List<Order> orders;
}

public class Order 
{
    public string orderName;

    public string shippingAdresse;

    public string price;
}