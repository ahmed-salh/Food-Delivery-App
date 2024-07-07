using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductDetails : MonoBehaviour
{

    [SerializeField]
    private Text productName;

    [SerializeField]
    private Text productPrice;

    [SerializeField]
    private TMP_Text Name;

    [SerializeField]
    private TMP_Text Price;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => { UpdateProductDetails(); });
    }

    public void UpdateProductDetails()
    {
        Name.text = productName.text;

        Price.text = productPrice.text;
    }
}
