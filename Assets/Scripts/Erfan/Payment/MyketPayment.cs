using System;
using UnityEngine;
using MyketPlugin;
using TMPro;
using UnityEngine.UI;


[Serializable]
public class Products
{
    public int code;
    public string id;
    public enum State
    {
        Consume,
        NoConsume,
    }

    public State state;
}
public class MyketPayment : MonoBehaviour
{
    #region Varibales

    [Header("Base Setting")]
    [SerializeField] [TextArea] private string myketKey;
    [SerializeField] private Products[] product;
    private int _selectedProduct;

    [Header("Ui Setting")] 
    [SerializeField] private GameObject loadingPanel;
    [SerializeField] private Button vipButton;

    [Header("Key and Value")]
    [SerializeField] [TextArea] private string keyVip;
    [SerializeField] [TextArea] private string vipValue;

    [Header("Vip")]
    [SerializeField] private VIPManager vipManager;
    [SerializeField] private GameObject vipIcon;
    #endregion

    #region Unity Methods

    private void Awake()
    {
        MyketIAB.init(myketKey);
    }

    private void Start()
    {
        if (vipManager.HaveVipRequest())
        {
            vipButton.interactable = false;
        }
    }

    #endregion

    #region Buttons

    public void BuyProduct(int code)
    {
        _selectedProduct = code;
        Products pro = product[code];
        loadingPanel.SetActive(true);
        
        if (pro.state == Products.State.NoConsume)
        {
            MyketIAB.purchaseProduct(pro.id);
        }
        else if (pro.state == Products.State.Consume)
        {
            MyketIAB.purchaseProduct(pro.id);
            MyketIAB.consumeProduct(pro.id);
        }
    }
    

    #endregion

    #region MyRegion

    public void GetBuyingRequest(MyketPurchase productState)
    {
        SuccessPayment(productState);
    }

    public void FailPayment(string error)
    {
        loadingPanel.GetComponentInChildren<TMP_Text>().text = $".ﺩﻮﺒﻧ ﺰﯿﻣﺁ ﺖﯿﻘﻓﻮﻣ ﺪﯾﺮﺧ" +
                                                               $"\n{error}";
    }

    #endregion

    
    #region Action

    private void SuccessPayment(MyketPurchase productState)
    {
        loadingPanel.GetComponentInChildren<TMP_Text>().text =
            $"ﺪﺷ ﻡﺎﺠﻧﺍ ﺖﯿﻘﻓﻮﻣ ﺎﺑ ﺪﯾﺮﺧ\n.ﺖﺳﺍ ﺮﯾﺯ ﺕﺭﻮﺻ ﻪﺑ ﺪﯾﺮﺧ ﺕﺎﺼﺨﺸﻣ\n\nﺮﮑﺸﺗ ﺎﺑ" +
            $"\n{productState.OrderId}\n" +
            $"{productState.PurchaseTime.ToString()}";
        
        switch (_selectedProduct)
        {
            case 0:
                PlayerPrefs.SetString(keyVip, vipValue);
                vipIcon.SetActive(false);
                vipButton.interactable = false;
                vipManager.SendActiveRequest(0);
                break;
        }
    }

    #endregion
    
    
}
