using Firebase.Extensions;
using System.Collections;
using Firebase.Auth;
using UnityEngine;
using Firebase;
using TMPro;
using UnityEngine.UI;


public class EmailPassAuth : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private InputField signUpEmail, signUpPass;

    [SerializeField]
    private InputField logInEmail, logInPass;

    [SerializeField]
    private InputField firstName, lastName;

    [SerializeField]
    private InputField phoneNo;

    [SerializeField]
    private PanelsManager panelsManager;

    [SerializeField]
    private TMP_Text errorText;

    [SerializeField]
    private PastOrdersController pastOrdersController;

    #endregion

    #region Methods

    private void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync();
    }

    public void SignUp()
    {
        panelsManager.SetLoadingPanel(true);

        errorText.gameObject.SetActive(true);

        FirebaseAuth auth = FirebaseAuth.DefaultInstance;

        string email = signUpEmail.text;

        string password = signUpPass.text;

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {

            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                panelsManager.SetLoadingPanel(false);

                errorText.text = "Failed sign up. Try again!";

                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);

                return;
            }

            AddNewUserData(FirebaseAuth.DefaultInstance.CurrentUser.UserId);

            errorText.gameObject.SetActive(false);

            panelsManager.SetLoadingPanel(false);

            panelsManager.SetLogInPanel(true);

            panelsManager.SetSignUpPanel(false);

            ClearInputFields();
        });
    }

    public void Login()
    {
        panelsManager.SetLoadingPanel(true);

        errorText.gameObject.SetActive(true);

        FirebaseAuth auth = FirebaseAuth.DefaultInstance;

        string email = logInEmail.text;

        string password = logInPass.text;

        Credential credential = EmailAuthProvider.GetCredential(email, password);

        auth.SignInAndRetrieveDataWithCredentialAsync(credential).ContinueWithOnMainThread(task => {
            
            panelsManager.SetLoadingPanel(false);

            if (task.IsCanceled)
            {
                return;
            }

            if (task.IsFaulted)
            {
                errorText.text = "Failed to Log In. Try again!";

                return;
            }

            errorText.gameObject.SetActive(false);

            panelsManager.SetMainPanel(true);

            panelsManager.SetLogInPanel(false);

            DataSync.DefaultInstance.DownloadUserData();

            DataSync.DefaultInstance.DownloadPastOrdersData();

            ClearInputFields();
        });
    }

    public void AddNewUserData(string UserID) 
    {
        User newUser = new User();

        newUser.firstName = firstName.text;

        newUser.lastName = lastName.text;

        newUser.phoneNo = phoneNo.text;

        UserData data = new UserData();

        data.CurrentUser = newUser;

        DataSync.DefaultInstance.UploadUserData(data);
    }

    public void ClearInputFields() 
    {
        signUpEmail.text = "";

        signUpPass.text = "";

        firstName.text = "";

        lastName.text = "";

        phoneNo.text = "";

        logInEmail.text = "";

        logInPass.text = "";
    }

    public void Logout()
    {
        errorText.gameObject.SetActive(false);

        FirebaseAuth.DefaultInstance.SignOut();

        pastOrdersController.ClearPastOrders();
    }
    #endregion
}