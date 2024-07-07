using System.Collections;
using UnityEngine;

public class PanelsManager : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup loginPanel, signUpPanel;

    [SerializeField]
    private CanvasGroup mainPanel;

    [SerializeField]
    private CanvasGroup loadingPanel;

    [SerializeField]
    private CanvasGroup pastOrdersPanel, ordersPanel;

    [SerializeField]
    private CanvasGroup restaurantsPanel;

    [SerializeField]
    private Transform[] restaurants;

    public void SetSignUpPanel(bool State)
    {
        if (State)
        {
            StartCoroutine(FadeInOut(signUpPanel, 1));
            signUpPanel.blocksRaycasts = true;
            signUpPanel.interactable = true;
        }
        else
        {
            StartCoroutine(FadeInOut(signUpPanel, 0));
            signUpPanel.blocksRaycasts = false;
            signUpPanel.interactable = false;
        }
    }

    public void SetLoadingPanel(bool State)
    {
        if (State)
        {
            StartCoroutine(FadeInOut(loadingPanel, 1));
            loadingPanel.blocksRaycasts = true;
            loadingPanel.interactable = true;
        }
        else
        {
            StartCoroutine(FadeInOut(loadingPanel, 0));
            loadingPanel.blocksRaycasts = false;
            loadingPanel.interactable = false;
        }
    }

    public void SetLogInPanel(bool State)
    {
        if (State)
        {
            StartCoroutine(FadeInOut(loginPanel, 1));
            loginPanel.blocksRaycasts = true;
            loginPanel.interactable = true;
        }
        else
        {
            StartCoroutine(FadeInOut(loginPanel, 0));
            loginPanel.blocksRaycasts = false;
            loginPanel.interactable = false;
        }
    }

    public void SetMainPanel(bool State)
    {
        if (State)
        {
            StartCoroutine(FadeInOut(mainPanel, 1));
            mainPanel.blocksRaycasts = true;
            mainPanel.interactable = true;
        }
        else
        {
            StartCoroutine(FadeInOut(mainPanel, 0));
            mainPanel.blocksRaycasts = false;
            mainPanel.interactable = false;
        }
    }

    public void SetPastOrderPanel(bool State)
    {
        if (State)
        {
            StartCoroutine(FadeInOut(pastOrdersPanel, 1));
            pastOrdersPanel.blocksRaycasts = true;
            pastOrdersPanel.interactable = true;
        }
        else
        {
            StartCoroutine(FadeInOut(pastOrdersPanel, 0));
            pastOrdersPanel.blocksRaycasts = false;
            pastOrdersPanel.interactable = false;
        }
    }

    public void SetOrdersPanel(bool State)
    {
        if (State)
        {
            StartCoroutine(FadeInOut(ordersPanel, 1));
            ordersPanel.blocksRaycasts = true;
            ordersPanel.interactable = true;
        }
        else
        {
            StartCoroutine(FadeInOut(ordersPanel, 0));
            ordersPanel.blocksRaycasts = false;
            ordersPanel.interactable = false;
        }
    }

    public void SetRestaurantPanel(bool State)
    {
        if (State)
        {
            StartCoroutine(FadeInOut(restaurantsPanel, 1));
            restaurantsPanel.blocksRaycasts = true;
            restaurantsPanel.interactable = true;
                
        }
        else
        {
            StartCoroutine(FadeInOut(restaurantsPanel, 0));
            restaurantsPanel.blocksRaycasts = false;
            restaurantsPanel.interactable = false;
        }
    }

    public void SetRestaurant(int index) 
    {
        foreach (var item in restaurants)
        {
            item.gameObject.SetActive(false);
        }

        restaurants[index].gameObject.SetActive(true);
    }


    // Coroutine to increase/decrease the opcaity of specific canvas group
    private IEnumerator FadeInOut(CanvasGroup canvasGroup, float endValue)
    {
        while (Mathf.Abs(canvasGroup.alpha - endValue) >= 0.001)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, endValue, Time.deltaTime * 25);

            yield return null;
        }

        canvasGroup.alpha = Mathf.Round(canvasGroup.alpha);
    }
}
